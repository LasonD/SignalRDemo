using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SignalRDemo.Server.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SignalRDemo.Server.Dto;
using SignalRDemo.Server.Models;
using SignalRDemo.Server.Exceptions;

namespace SignalRDemo.Server.Services;

public interface IAuthService
{
    Task<AuthResult?> AuthenticateUserAsync(LoginRequest loginData, CancellationToken cancellationToken);
    Task<AuthResult> RegisterUserAsync(RegisterRequest registrationData, CancellationToken cancellationToken);
}

public class AuthService : IAuthService
{
    private const int MsInSec = 1000;
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;

    public AuthService(UserManager<User> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }

    public async Task<AuthResult?> AuthenticateUserAsync(LoginRequest loginData, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var user = await _userManager.FindByEmailAsync(loginData.Email);

        if (user == null)
        {
            return null;
        }

        var isValidPassword = await _userManager.CheckPasswordAsync(user, loginData.Password);

        if (!isValidPassword)
        {
            return null;
        }

        var authResult = await PrepareAuthResultAsync(user);

        return authResult;
    }

    public async Task<AuthResult> RegisterUserAsync(RegisterRequest registrationData, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var newUser = new User()
        {
            Email = registrationData.Email,
            UserName = registrationData.UserName,
        };

        var userJurisdictions = registrationData.Jurisdictions.Select(j => new Jurisdiction(j)).ToList();

        newUser.Jurisdictions.AddRange(userJurisdictions);

        var identityResult = await _userManager.CreateAsync(newUser, registrationData.Password);

        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(e => $"{e.Code} : {e.Description}").ToList();

            throw new RegistrationException(errors);
        }

        var authResult = await PrepareAuthResultAsync(newUser);

        return authResult;
    }

    #region Private methods

    private async Task<AuthResult> PrepareAuthResultAsync(User user)
    {
        var tokenClaims = await CollectClaimsAsync(user);
        var tokenStr = GenerateToken(tokenClaims);

        var tokenDurationMinutes = _config.GetTokenDurationMinutes();
        var durationMs = tokenDurationMinutes * MsInSec;

        var authResult = new AuthResult()
        {
            Email = user.Email!,
            UserId = user.Id,
            AccessToken = tokenStr,
            ExpiresIn = durationMs,
        };

        return authResult;
    }

    private string GenerateToken(IEnumerable<Claim> tokenClaims)
    {
        var tokenDurationMinutes = _config.GetTokenDurationMinutes();
        var issuer = _config.GetIssuer();
        var audience = _config.GetAudience();
        var tokenGenerationKey = _config.GetTokenGenerationKey();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenGenerationKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expirationTime = DateTime.UtcNow.AddMinutes(tokenDurationMinutes);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: tokenClaims,
            expires: expirationTime,
            signingCredentials: credentials
        );

        var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenStr;
    }

    private async Task<List<Claim>> CollectClaimsAsync(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = await _userManager.GetClaimsAsync(user);

        var tokenClaims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }
            .Union(claims)
            .Union(roles.Select(r => new Claim(ClaimTypes.Role, r)))
            .ToList();

        if (user.Email != null)
        {
            tokenClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        }

        return tokenClaims;
    }

    #endregion
}