namespace SignalRDemo.Server.Dto;

public record RegisterRequest(string Email, string Password, string UserName, ICollection<string> Jurisdictions);