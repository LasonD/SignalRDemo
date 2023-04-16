namespace SignalRDemo.Server.Application.Dto.Auth;

public record RegisterRequest(string Email, string Password, string UserName, ICollection<string> Jurisdictions);