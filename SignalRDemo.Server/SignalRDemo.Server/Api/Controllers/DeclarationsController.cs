using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.UseCases.Commands;

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

    [HttpPost("declarations")]
    public async Task<IActionResult> CreateDeclaration(CreateDeclarationDto createDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateDeclaration.Command>(createDeclaration);

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPut("declarations")]
    public async Task<IActionResult> UpdateDeclaration(UpdateDeclarationDto updateDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateDeclaration.Command>(updateDeclaration);

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}