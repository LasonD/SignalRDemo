using Microsoft.AspNetCore.Identity;

namespace SignalRDemo.Server.Application.Models;

public class User : IdentityUser
{
    public List<Declaration> Declarations { get; set; } = new();

    public List<Jurisdiction> Jurisdictions { get; set; } = new();
}