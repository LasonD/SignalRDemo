using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.UseCases.Commands;

public static class CreateDeclaration
{
    public class Command : IRequest<DeclarationDto>
    {
        public string DeclarantId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Jurisdiction { get; set; } = null!;
        public decimal NetMass { get; set; }
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

            RuleFor(x => x.NetMass)
                .GreaterThan(0)
                .WithMessage("Declaration should have a positive NetMass.");
        }
    }

    public class Handler : IRequestHandler<Command, DeclarationDto>
    {
        private readonly IMapper _mapper;
        private readonly DeclarationsDbContext _dbContext;
        private readonly INotificationsService _notificationsService;

        public Handler(IMapper mapper, DeclarationsDbContext dbContext, INotificationsService notificationsService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _notificationsService = notificationsService;
        }

        public async Task<DeclarationDto> Handle(Command command, CancellationToken cancellationToken)
        {
            var jurisdiction = await _dbContext.Jurisdictions.FindAsync(command.Jurisdiction);

            var newDeclaration = _mapper.Map<Declaration>(command);
            newDeclaration.Jurisdiction = jurisdiction!;

            _dbContext.Declarations.Add(newDeclaration);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<DeclarationDto>(newDeclaration);

            await _notificationsService.NotifyDeclarationCreatedAsync(dto, cancellationToken);

            return dto;
        }
    }
}