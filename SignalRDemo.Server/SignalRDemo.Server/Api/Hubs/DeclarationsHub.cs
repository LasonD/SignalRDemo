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
    Task DeclarationDeleted(string declarationId);

    Task DeclarationEditToggled(string declarationId);
    Task DeclarationEditCancelled(string declarationId);

    Task UserConnected(string email);
    Task UserDisconnected(string email);
}

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DeclarationsHub : Hub<IDeclarationsHub>
{
    private readonly IDeclarationsCacheManager _declarationsCacheManager;
    private readonly DeclarationsDbContext _dbContext;

    public DeclarationsHub(DeclarationsDbContext dbContext, IDeclarationsCacheManager declarationsCacheManager)
    {
        _dbContext = dbContext;
        _declarationsCacheManager = declarationsCacheManager;
    }

    public async Task DeclarationEditToggled(string declarationId)
    {
        _declarationsCacheManager.Lock(declarationId, UserId);

        var jurisdiction = await GetDeclarationJurisdictionAsync(declarationId);

        var groupName = HubHelper.GetGroupNameForJurisdiction(jurisdiction);

        await Clients.OthersInGroup(groupName).DeclarationEditToggled(declarationId);
    }

    public async Task DeclarationEditCancelled(string declarationId)
    {
        _declarationsCacheManager.Unlock(declarationId);

        var jurisdiction = await GetDeclarationJurisdictionAsync(declarationId);

        var groupName = HubHelper.GetGroupNameForJurisdiction(jurisdiction);

        await Clients.OthersInGroup(groupName).DeclarationEditCancelled(declarationId);
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
            await Groups.AddToGroupAsync(connectionId, groupName);
            await Clients.GroupExcept(groupName, new[] { connectionId }).UserDisconnected(email);
        }));

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