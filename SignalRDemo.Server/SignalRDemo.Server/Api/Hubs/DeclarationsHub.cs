using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Common.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalRDemo.Server.Api.Hubs;

public interface IDeclarationsHub
{
    Task DeclarationCreated(DeclarationDto declaration);

    Task UserConnected(string email);

    Task UserDisconnected(string email);
}

[Authorize]
public class DeclarationsHub : Hub<IDeclarationsHub>
{
    public override async Task OnConnectedAsync()
    {
        var user = Context.User;
        var connectionId = Context.ConnectionId;
        var userJurisdictions = user.GetUserJurisdictionsFromClaims();

        var email = user.GetRequiredUserEmail();

        await Task.WhenAll(userJurisdictions.Select(async j =>
        {
            var groupName = $"Jurisdiction_{j}";
            await Groups.AddToGroupAsync(connectionId, groupName);
            await Clients.Group(groupName).UserConnected(email);
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
            var groupName = $"Jurisdiction_{j}";
            await Groups.AddToGroupAsync(connectionId, groupName);
            await Clients.Group(groupName).UserDisconnected(email);
        }));

        await base.OnDisconnectedAsync(exception);
    }
}