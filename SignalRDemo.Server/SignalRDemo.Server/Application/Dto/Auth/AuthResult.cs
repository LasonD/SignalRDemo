namespace SignalRDemo.Server.Application.Dto.Auth;

public class AuthResult
{
    public string UserId { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
    public long ExpiresIn { get; set; }
}