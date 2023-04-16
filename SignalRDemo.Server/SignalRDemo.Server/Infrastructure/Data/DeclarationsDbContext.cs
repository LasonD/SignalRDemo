using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Models;

namespace SignalRDemo.Server.Infrastructure.Data;

public class DeclarationsDbContext : IdentityDbContext
{
    public DbSet<Declaration> Declarations { get; protected set; } = null!;
    public DbSet<Jurisdiction> Jurisdictions { get; protected set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Jurisdiction>()
            .HasKey(x => x.Code);

        base.OnModelCreating(builder);
    }
}