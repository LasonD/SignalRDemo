using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Data;
using SignalRDemo.Server.Dto;
using SignalRDemo.Server.Exceptions;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server.Commands;

public class UpdateDeclaration
{
    public class Command : IRequest<DeclarationDto>
    {
        public string Id { get; set; } = null!;
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
                .WithMessage(x => $"Cannot update jurisdiction. You are not authorized to create declarations for {x} jurisdiction.")
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
            var declaration = await _dbContext.Declarations.FindAsync(request.Id, cancellationToken);

            if (declaration == null)
            {
                throw new NotFoundException(request.Id, nameof(Declaration));
            }

            _mapper.Map(request, declaration);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<DeclarationDto>(declaration);

            return dto;
        }
    }
}