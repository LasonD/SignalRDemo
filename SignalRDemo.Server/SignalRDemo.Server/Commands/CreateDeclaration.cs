using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Data;
using SignalRDemo.Server.Dto;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server.Commands;

public class CreateDeclaration
{
    public class Command : IRequest<DeclarationDto>
    {
        public string DeclarantId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Jurisdiction { get; set; } = null!;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator(DeclarationsDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Declaration description cannot be empty.");

            RuleFor(x => x.Jurisdiction)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithName("Declaration should have non-empty jurisdiction.")
                .Must(x => user?.HasClaim(c => c.Type == Constants.JurisdictionClaimType && c.Value == x) ?? false)
                .WithMessage(x => $"You are not authorized to create declarations for {x} jurisdiction.")
                .MustAsync((x, ct) => dbContext.Jurisdictions.AnyAsync(j => j.Code == x, ct))
                .WithMessage(x => $"{x.Jurisdiction} is not a known jurisdiction.");
        }
    }

    public class Handler : IRequestHandler<Command, DeclarationDto>
    {
        private readonly IMapper _mapper;
        private readonly DeclarationsDbContext _dbContext;

        public Handler(IMapper mapper, DeclarationsDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<DeclarationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var newDeclaration = new Declaration()
            {
                Description = request.Description,
                Jurisdiction = new Jurisdiction(request.Jurisdiction),
                DeclarantId = request.DeclarantId
            };

            await _dbContext.Declarations.AddAsync(newDeclaration, cancellationToken);

            return _mapper.Map<DeclarationDto>(newDeclaration);
        }
    }
}