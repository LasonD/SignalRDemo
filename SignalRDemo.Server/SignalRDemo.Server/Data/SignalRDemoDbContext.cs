using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server.Data;

public class SignalRDemoDbContext : IdentityDbContext
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