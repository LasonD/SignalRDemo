using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Server.Hubs;

namespace SignalRDemo.Server.Controllers;

[ApiController]
public class DeclarationsController : ControllerBase
{
    private readonly IHubContext<DeclarationsHub> _declarationsHubContext;

    public DeclarationsController(IHubContext<DeclarationsHub> declarationsHubContext)
    {
        _declarationsHubContext = declarationsHubContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration(DeclarationsHub declaration, CancellationToken cancellationToken)
    {
        await _declarationsHubContext.Clients.All.SendAsync("DeclarationCreated", declaration, cancellationToken);
        
        return Ok(declaration);
    }
}