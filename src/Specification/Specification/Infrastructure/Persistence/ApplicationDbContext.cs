using Microsoft.EntityFrameworkCore;
using Specification.Core.Domain.Entity;
using Specification.Infrastructure.Persistence.EntityConfiguration;
using Specification.Infrastructure.Persistence.SeedData;

namespace Specification.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Circle> Circles { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
               .ApplyConfiguration(new UserEntityConfiguration())
               .ApplyConfiguration(new CircleEntityConfiguration());

        builder.HasDataUser()
            .HasDataCircle();
    }
}
