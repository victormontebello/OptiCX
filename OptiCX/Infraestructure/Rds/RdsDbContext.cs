using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Rds;

public class RdsDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    public RdsDbContext(DbContextOptions<RdsDbContext> options) : base(options)
    {
    }
}