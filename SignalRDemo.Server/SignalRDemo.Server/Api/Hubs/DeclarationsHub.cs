using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Common.Helpers;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Api.Hubs;

public interface IDeclarationsHub
{
    Task DeclarationCreated(DeclarationDto declaration);
    Task DeclarationUpdated(DeclarationDto declaration);
    Task DeclarationEditChange(DeclarationChange change);
    Task DeclarationDeleted(string declarationId);

    Task DeclarationEditToggled(string declarationId);
    Task DeclarationEditCancelled(string declarationId);

    Task UserConnected(string email);
    Task UserDisconnected(string email);
}

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DeclarationsHub : Hub<IDeclarationsHub>
{
    private readonly IDeclarationsLockManager _declarationsLockManager;
    private readonly DeclarationsDbContext _dbContext;

    public DeclarationsHub(DeclarationsDbContext dbContext, IDeclarationsLockManager declarationsLockManager)
    {
        _dbContext = dbContext;
        _declarationsLockManager = declarationsLockManager;
    }

    public async Task DeclarationEditToggled(string declarationId)
    {
        _declarationsLockManager.Lock(declarationId, UserId);

        var jurisdiction = await GetDeclarationJurisdictionAsync(declarationId);

        var groupName = HubHelper.GetGroupNameForJurisdiction(jurisdiction);

        await Clients.OthersInGroup(groupName).DeclarationEditToggled(declarationId);
    }

    public async Task DeclarationEditCancelled(string declarationId)
    {
        _declarationsLockManager.Unlock(declarationId);

        var jurisdiction = await GetDeclarationJurisdictionAsync(declarationId);

        var groupName = HubHelper.GetGroupNameForJurisdiction(jurisdiction);

        await Clients.OthersInGroup(groupName).DeclarationEditCancelled(declarationId);
    }

    public async Task DeclarationChanged(DeclarationChange change)
    {
        //  TODO: add checks

        await Clients.All.DeclarationEditChange(change);
    }

    public override async Task OnConnectedAsync()
    {
        var user = Context.User;
        var connectionId = Context.ConnectionId;
        var userJurisdictions = user.GetUserJurisdictionsFromClaims();

        var email = user.GetRequiredUserEmail();

        await Task.WhenAll(userJurisdictions.Select(async j =>
        {
            var groupName = HubHelper.GetGroupNameForJurisdiction(j);
            await Groups.AddToGroupAsync(connectionId, groupName);
            await Clients.GroupExcept(groupName, new[] { connectionId }).UserConnected(email);
        }));

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var user = Context.User;
        var connectionId = Context.ConnectionId;
        var userJurisdictions = user.GetUserJurisdictionsFromClaims();

        var email = user.GetRequiredUserEmail();

        await Task.WhenAll(userJurisdictions.Select(async j =>
        {
            var groupName = HubHelper.GetGroupNameForJurisdiction(j);
            await Groups.RemoveFromGroupAsync(connectionId, groupName);
            await Clients.GroupExcept(groupName, new[] { connectionId }).UserDisconnected(email);
        }));

        var releasedDeclarations = _declarationsLockManager.UnlockAllLockedBy(UserId);

        foreach (var releasedDeclarationId in releasedDeclarations)
        {
            await Clients.All.DeclarationEditCancelled(releasedDeclarationId);
        }

        await base.OnDisconnectedAsync(exception);
    }

    private string UserId => Context.User?.GetUserId()!;

    private async Task<string> GetDeclarationJurisdictionAsync(string declarationId)
    {
        var declaration = await _dbContext.Declarations.FindAsync(declarationId);

        if (declaration?.JurisdictionCode == null)
        {
            throw new NotFoundException(declarationId, nameof(Declaration));
        }

        return declaration.JurisdictionCode;
    }
}