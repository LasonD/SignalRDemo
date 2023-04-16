namespace SignalRDemo.Server.Dto;

public class AuthResult
{
    public string UserId { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
    public long ExpiresIn { get; set; }
}