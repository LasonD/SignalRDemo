using AutoMapper;
using FluentValidation;
using MediatR;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.UseCases.Commands;

public static class DeleteDeclaration
{
    public class Command : IRequest<DeclarationDto>
    {
        public string Id { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string[] UserJurisdictions { get; set; } = null!;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Declaration Id cannot be empty.");

            RuleFor(x => x.UserJurisdictions)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithName("User should have have access to at least one jurisdiction to delete declarations.");
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
            var declaration = await _dbContext.Declarations.FindAsync(command.Id, cancellationToken);

            if (declaration == null)
            {
                throw new NotFoundException(command.Id, nameof(Declaration));
            }

            if (!command.UserJurisdictions.Contains(declaration.JurisdictionCode))
            {
                throw new BusinessException($"The user {command.UserId} is not eligible to delete declarations for {declaration.JurisdictionCode} jurisdiction");
            }

            var removedDeclaration = _dbContext.Declarations.Remove(declaration);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<DeclarationDto>(removedDeclaration);

            await _notificationsService.NotifyDeclarationDeletedAsync(dto.Id, dto.Jurisdiction, cancellationToken);

            return dto;
        }
    }
}