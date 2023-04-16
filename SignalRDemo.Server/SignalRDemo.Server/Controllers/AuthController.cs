using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Commands;
using SignalRDemo.Server.Dto;

namespace SignalRDemo.Server.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.AuthenticateUserAsync(request, cancellationToken);

        return Ok(result);
    }

    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterUserAsync(request, cancellationToken);

        return Ok(result);
    }
}