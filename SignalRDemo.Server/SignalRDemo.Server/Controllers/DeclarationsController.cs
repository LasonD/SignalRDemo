using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Server.Hubs;

namespace SignalRDemo.Server.Controllers;

[ApiController]
public class DeclarationsController : ControllerBase
{
    private readonly IHubContext<DeclarationsHub> declarationsHubContext;

    public DeclarationsController(IHubContext<DeclarationsHub> declarationsHubContext)
    {
        this.declarationsHubContext = declarationsHubContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration(DeclarationsHub declaration)
    {
        await declarationsHubContext.Clients.All.SendAsync("DeclarationCreated", declaration);

        return Ok(declaration);
    }
}