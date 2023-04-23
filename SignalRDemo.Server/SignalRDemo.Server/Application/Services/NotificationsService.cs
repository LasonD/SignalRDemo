using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Server.Api.Hubs;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Common.Helpers;

namespace SignalRDemo.Server.Application.Services;

public interface INotificationsService
{
    Task NotifyDeclarationDeletedAsync(string declarationId, string jurisdiction, CancellationToken cancellationToken);
    Task NotifyDeclarationUpdatedAsync(DeclarationDto updatedDeclaration, CancellationToken cancellationToken);
    Task NotifyDeclarationCreatedAsync(DeclarationDto createdDeclaration, CancellationToken cancellationToken);
}

public class NotificationsService : INotificationsService
{
    private readonly IHubContext<DeclarationsHub, IDeclarationsHub> _hubContext;

    public NotificationsService(IHubContext<DeclarationsHub, IDeclarationsHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyDeclarationDeletedAsync(string declarationId, string jurisdiction, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var jurisdictionGroup = HubHelper.GetGroupNameForJurisdiction(jurisdiction);

        await _hubContext.Clients.Group(jurisdictionGroup).DeclarationDeleted(declarationId);
    }

    public async Task NotifyDeclarationUpdatedAsync(DeclarationDto updatedDeclaration, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var jurisdictionGroup = HubHelper.GetGroupNameForJurisdiction(updatedDeclaration.Jurisdiction);

        await _hubContext.Clients.Group(jurisdictionGroup).DeclarationUpdated(updatedDeclaration);
    }

    public async Task NotifyDeclarationCreatedAsync(DeclarationDto createdDeclaration, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var jurisdictionGroup = HubHelper.GetGroupNameForJurisdiction(createdDeclaration.Jurisdiction);

        await _hubContext.Clients.Group(jurisdictionGroup).DeclarationCreated(createdDeclaration);
    }
}