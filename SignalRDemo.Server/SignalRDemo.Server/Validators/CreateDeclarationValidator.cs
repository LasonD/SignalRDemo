using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Data;
using SignalRDemo.Server.Dto;

namespace SignalRDemo.Server.Validators;

public class CreateDeclarationValidator : AbstractValidator<CreateDeclarationRequest>
{
    public CreateDeclarationValidator(SignalRDemoDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Declaration description cannot be empty.");

        RuleFor(x => x.Jurisdiction)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(x => user?.HasClaim(c => c.Type == Constants.JurisdictionClaimType && c.Value == x) ?? false)
            .WithMessage(x => $"You are not authorized to create declarations for {x} jurisdiction")
            .MustAsync((x, ct) => dbContext.Jurisdictions.AnyAsync(j => j.Code == x, ct))
            .WithMessage(x => $"{x.Jurisdiction} is not a known jurisdiction.");
    }
}