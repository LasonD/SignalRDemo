using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.UseCases.Commands;

public static class UpdateJurisdiction
{
    public class Command : IRequest<JurisdictionDto>
    {
        public string JurisdictionCode { get; set; } = null!;
        public string Color { get; set; } = null!;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator(DeclarationsDbContext dbContext, IHttpContextAccessor httpContextAccessor, IDeclarationsLockManager declarationsLockManager)
        {
            var user = httpContextAccessor.HttpContext?.User;

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Jurisdiction color should not be empty.");

            RuleFor(x => x.JurisdictionCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithName("Declaration should have non-empty jurisdiction.")
                .Must(x => user?.HasClaim(c => c.Type == Constants.JurisdictionClaimType && c.Value == x) ?? false)
                .WithMessage(x => $"Cannot update jurisdiction. You are not authorized to create declarations for {x} jurisdiction.")
                .MustAsync((x, ct) => dbContext.Jurisdictions.AnyAsync(j => j.Code == x, ct))
                .WithMessage(x => $"{x.JurisdictionCode} is not a known jurisdiction.");
        }
    }

    public class Handler : IRequestHandler<Command, JurisdictionDto>
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

        public async Task<JurisdictionDto> Handle(Command command, CancellationToken cancellationToken)
        {
            var jurisdiction = await _dbContext.Jurisdictions.FindAsync(command.JurisdictionCode);

            if (jurisdiction == null)
            {
                throw new NotFoundException(command.JurisdictionCode, nameof(Jurisdiction));
            }

            jurisdiction.DisplayColor = command.Color;

            await _dbContext.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<JurisdictionDto>(jurisdiction);

            await _notificationsService.NotifyJurisdictionUpdatedAsync(dto, cancellationToken);

            return dto;
        }
    }
}