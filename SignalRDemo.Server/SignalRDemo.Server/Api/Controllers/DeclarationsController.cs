using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.Commands;
using SignalRDemo.Server.Application.Dto;

namespace SignalRDemo.Server.Api.Controllers;

[ApiController]
public class DeclarationsController : ClientControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DeclarationsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration(CreateDeclarationDto createDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateDeclaration.Command>(createDeclaration);

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDeclaration(UpdateDeclarationDto updateDeclaration, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateDeclaration.Command>(updateDeclaration);

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}