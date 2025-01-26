using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Rds;

public class RdsDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public RdsDbContext(DbContextOptions<RdsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}