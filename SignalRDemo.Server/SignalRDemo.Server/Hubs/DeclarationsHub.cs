using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Server.Hubs;

public interface IDeclarationsHub
{
    Task Notify(string text);
}

public class DeclarationsHub : Hub<IDeclarationsHub>
{
    public async Task Notify(string text)
    {
        await Clients.All.Notify(text);
    }
}



