using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Common.Helpers;

namespace SignalRDemo.Server.Api.Controllers;

public abstract class ClientControllerBase : ControllerBase
{
    protected string GetRequiredAppUserId()
    {
        var userId = UserIdClaimHelper.RetrieveUserId(User);

        if (userId == null)
        {
            throw new AuthException(new List<string> { "User id should be specified." });
        }

        return userId;
    }
}