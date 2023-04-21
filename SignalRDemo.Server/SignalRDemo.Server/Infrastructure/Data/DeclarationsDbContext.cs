using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Models;

namespace SignalRDemo.Server.Infrastructure.Data;

public class DeclarationsDbContext : IdentityDbContext
{
    public DeclarationsDbContext(DbContextOptions<DeclarationsDbContext> options) : base(options)
    {

    }

    public DbSet<Declaration> Declarations { get; protected set; } = null!;
    public DbSet<Jurisdiction> Jurisdictions { get; protected set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Jurisdiction>()
            .HasKey(x => x.Code);

        builder.Entity<Jurisdiction>()
            .HasData(
                new Jurisdiction("GB", "blue"),
                new Jurisdiction("BE", "orange"),
                new Jurisdiction("DE", "olive"),
                new Jurisdiction("IE", "green"),
                new Jurisdiction("NL", "aqua"),
                new Jurisdiction("PL", "red")
            );

        base.OnModelCreating(builder);
    }
}