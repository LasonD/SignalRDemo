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
}