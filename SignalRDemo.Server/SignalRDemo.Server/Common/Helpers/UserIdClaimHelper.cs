using System.Security.Claims;

namespace SignalRDemo.Server.Common.Helpers;

public static class UserIdClaimHelper
{
    private const string AppUserIdClaimType = nameof(AppUserIdClaimType);

    public static Claim CreateClaim(string userId)
    {
        return new Claim(AppUserIdClaimType, userId);
    }

    public static string? RetrieveUserId(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst(AppUserIdClaimType)?.Value;
    }
}