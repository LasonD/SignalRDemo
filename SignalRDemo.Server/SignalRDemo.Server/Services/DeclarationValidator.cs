using Microsoft.AspNetCore.Identity;
using SignalRDemo.Server.Dto;

namespace SignalRDemo.Server.Services;

public class DeclarationValidator
{
    private readonly UserManager<IdentityUser> _userManager;

    public DeclarationValidator(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public IReadOnlyCollection<Error> Validate(string userId, CreateDeclarationRequest request)
    {

    }
}