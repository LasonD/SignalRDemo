using Microsoft.AspNetCore.Identity;

namespace SignalRDemo.Server.Application.Models;

public class User : IdentityUser
{
    public List<Declaration> Declarations { get; protected set; } = new();

    public List<Jurisdiction> Jurisdictions { get; protected set; } = new();
}