using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.UseCases.Queries;

namespace SignalRDemo.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JurisdictionsController : ClientControllerBase
{
    private readonly IMediator _mediator;

    public JurisdictionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> CreateDeclaration(CancellationToken cancellationToken)
    {
        var command = new GetJurisdictions.Query();

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}