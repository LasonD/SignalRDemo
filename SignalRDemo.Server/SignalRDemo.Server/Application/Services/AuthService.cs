using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignalRDemo.Server.Application.Dto.Auth;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Common.Helpers;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.Services;

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
    private readonly DeclarationsDbContext _dbContext;

    public AuthService(UserManager<User> userManager, DeclarationsDbContext dbContext, IConfiguration config)
    {
        _userManager = userManager;
        _dbContext = dbContext;
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

        await _dbContext.Entry(user)
            .Collection(u => u.Jurisdictions)
            .LoadAsync(cancellationToken);

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

        var userJurisdictions = registrationData.Jurisdictions;

        var jurisdictions = await _dbContext.Jurisdictions
            .Where(j => userJurisdictions.Any(x => x == j.Code))
            .ToListAsync(cancellationToken);

        newUser.Jurisdictions.AddRange(jurisdictions);

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
            UserName = user.UserName,
            AccessToken = tokenStr,
            Jurisdictions = user.Jurisdictions.Select(x => x.Code).ToArray(),
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
        var jurisdictionCodes = user.Jurisdictions.Select(j => j.Code).ToList();
        var jurisdictionClaims = jurisdictionCodes.ToJurisdictionClaims();

        var tokenClaims = new List<Claim>()
            {
                user.Id.ToUserIdClaim(),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }
            .Union(claims)
            .Union(roles.Select(r => new Claim(ClaimTypes.Role, r)))
            .Union(jurisdictionClaims)
            .ToList();

        if (user.Email != null)
        {
            tokenClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        }

        return tokenClaims;
    }

    #endregion
}