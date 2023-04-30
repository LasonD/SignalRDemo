using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Models;

namespace SignalRDemo.Server.Infrastructure.Data;

public class DeclarationsDbContext : IdentityDbContext<User>
{
    public DeclarationsDbContext(DbContextOptions<DeclarationsDbContext> options) : base(options)
    {
    }

    public DbSet<Declaration> Declarations { get; protected set; } = null!;
    public DbSet<Jurisdiction> Jurisdictions { get; protected set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany(u => u.Jurisdictions)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserJurisdiction",
                b => b.HasOne<Jurisdiction>().WithMany().HasForeignKey("JurisdictionCode"),
                b => b.HasOne<User>().WithMany().HasForeignKey("UserId"));

        builder.Entity<Jurisdiction>()
            .HasKey(x => x.Code);

        builder.Entity<Declaration>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Declaration>()
            .HasKey(x => x.Id);

        builder.Entity<Declaration>()
            .HasOne(x => x.Jurisdiction)
            .WithMany()
            .HasForeignKey(x => x.JurisdictionCode);

        var jurisdictions = new Jurisdiction[]
        {
            new("GB", "blue"),
            new("BE", "orange"),
            new("DE", "olive"),
            new("IE", "green"),
            new("NL", "aqua"),
            new("PL", "red")
        };

        builder.Entity<Jurisdiction>()
            .HasData(jurisdictions);

        var roles = new IdentityRole[]
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpperInvariant(),
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "User".ToUpperInvariant(),
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var hasher = new PasswordHasher<User>();

        var users = new User[]
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com".ToUpperInvariant(),
                NormalizedUserName = "admin@localhost.com".ToUpperInvariant(),
                PasswordHash = hasher.HashPassword(null, "admin123"),
                EmailConfirmed = true,

            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "user@localhost.com",
                NormalizedEmail = "user@localhost.com".ToUpperInvariant(),
                NormalizedUserName = "user@localhost.com".ToUpperInvariant(),
                PasswordHash = hasher.HashPassword(null, "user123"),
                EmailConfirmed = true,
            }
        };

        builder.Entity<User>().HasData(users);

        builder.Entity("UserJurisdiction").HasData(
            new { UserId = users[0].Id, JurisdictionCode = "GB" },
            new { UserId = users[0].Id, JurisdictionCode = "BE" },
            new { UserId = users[0].Id, JurisdictionCode = "DE" },
            new { UserId = users[0].Id, JurisdictionCode = "IE" },
            new { UserId = users[0].Id, JurisdictionCode = "NL" },
            new { UserId = users[0].Id, JurisdictionCode = "PL" },
            new { UserId = users[1].Id, JurisdictionCode = "GB" },
            new { UserId = users[1].Id, JurisdictionCode = "BE" },
            new { UserId = users[1].Id, JurisdictionCode = "DE" }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = roles[0].Id,
                UserId = users[0].Id,
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles[1].Id,
                UserId = users[1].Id,
            }
        );

        var declarations = new List<Declaration>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test GB declaration 1",
                JurisdictionCode = "GB",
                DeclarantId = users[0].Id,
                NetMass = 80,
                CreationDate = DateTime.UtcNow.AddHours(-72),
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test BE declaration 1",
                JurisdictionCode = "BE",
                DeclarantId = users[0].Id,
                NetMass = 60,
                CreationDate = DateTime.UtcNow.AddHours(-48),
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test DE declaration 1",
                JurisdictionCode = "DE",
                DeclarantId = users[0].Id,
                NetMass = 50,
                CreationDate = DateTime.UtcNow.AddHours(-24),
            },

            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test GB declaration 2",
                JurisdictionCode = "GB",
                DeclarantId = users[1].Id,
                NetMass = 90,
                CreationDate = DateTime.UtcNow.AddHours(-36),
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test BE declaration 2",
                JurisdictionCode = "BE",
                DeclarantId = users[1].Id,
                NetMass = 70,
                CreationDate = DateTime.UtcNow.AddHours(-12),
            },
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test DE declaration 2",
                JurisdictionCode = "DE",
                DeclarantId = users[1].Id,
                NetMass = 40,
                CreationDate = DateTime.UtcNow,
            },
        };

        builder.Entity<Declaration>().HasData(declarations);

        base.OnModelCreating(builder);
    }
}