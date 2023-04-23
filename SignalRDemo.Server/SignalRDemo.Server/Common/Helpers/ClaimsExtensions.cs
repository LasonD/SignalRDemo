using System.IdentityModel.Tokens.Jwt;
using SignalRDemo.Server.Application.Exceptions;
using System.Security.Claims;

namespace SignalRDemo.Server.Common.Helpers;

public static class ClaimsExtensions
{ 
    public static string GetRequiredUserEmail(this ClaimsPrincipal? principal)
    {
        var email = principal?.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;

        if (email == null)
        {
            throw new AuthException("User must have email.");
        }

        return email;
    }

    public static IEnumerable<string> GetUserJurisdictionsFromClaims(this ClaimsPrincipal? principal)
    {
        var jurisdictionClaims = principal?.Claims
            .Where(c => c.Type == Constants.JurisdictionClaimType)
            .Select(c => c.Value)
            .ToList() ?? new List<string>();

        return jurisdictionClaims;
    }

    public static IEnumerable<Claim> ToJurisdictionClaims(this IEnumerable<string> jurisdictions)
    {
        return jurisdictions.Select(j => new Claim(Constants.JurisdictionClaimType, j)).ToList();
    }

    public static Claim ToUserIdClaim(this string userId)
    {
        return new Claim(Constants.AppUserIdClaimType, userId);
    }

    public static string? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst(Constants.AppUserIdClaimType)?.Value;
    }
}