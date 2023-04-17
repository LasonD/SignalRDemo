using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.Exceptions;

namespace SignalRDemo.Server.Api.Controllers;

public abstract class ClientControllerBase : ControllerBase
{
    protected string GetRequiredAppUserId()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);

        if (userId == null)
        {
            throw new AuthException(new List<string> { "User id should be specified." });
        }

        return userId.Value;
    }
}