using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.UseCases.Commands;
using SignalRDemo.Server.Application.UseCases.Queries;

namespace SignalRDemo.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeclarationsController : ClientControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DeclarationsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetDeclarations(CancellationToken cancellationToken)
    {
        var query = new GetDeclarations.Query { UserId = GetRequiredAppUserId() };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDeclaration(CreateDeclarationDto createDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateDeclaration.Command>(createDeclaration);
        command.DeclarantId = GetRequiredAppUserId();

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDeclaration(string id, UpdateDeclarationDto updateDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateDeclaration.Command>(updateDeclaration);
        command.Id = id;

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteDeclaration(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteDeclaration.Command
        {
            Id = id, 
            UserId = GetRequiredAppUserId(), 
            UserJurisdictions = GetCurrentUserJurisdictions()
        };

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}