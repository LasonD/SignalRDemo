using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.UseCases.Commands;

namespace SignalRDemo.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ClientControllerBase
{
    private const int DefaultCount = 10;
    private const int DefaultIntervalMs = 1000;

    private readonly IMediator _mediator;

    public DemoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDeclarations(int count = DefaultCount, int msInterval = DefaultIntervalMs, CancellationToken cancellationToken = default)
    {
        var testId = Guid.NewGuid();
        var rnd = new Random();
        var userId = GetRequiredAppUserId();
        var userJurisdictions = GetCurrentUserJurisdictions();

        if (count <= 0 || count > 1000)
        {
            count = DefaultCount;
        }

        if (msInterval <= 0)
        {
            msInterval = DefaultIntervalMs;
        }

        for (int i = 0; i < count; i++)
        {
            var command = new CreateDeclaration.Command
            {
                DeclarantId = userId,
                Jurisdiction = userJurisdictions[rnd.Next(userJurisdictions.Length)],
                Description = $"Declaration {i + 1} created by {userId} out of {count} during test {testId}",
                NetMass = rnd.Next(50, 150),
            };

            await _mediator.Send(command, cancellationToken);

            await Task.Delay(msInterval, cancellationToken);
        }

        return Ok();
    }
}