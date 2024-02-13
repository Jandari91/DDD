using Microsoft.EntityFrameworkCore;
using Specification.Core.Domain.Entity;
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

        builder.HasDataCircle().HasDataUser();

        builder.Entity<User>()
            .HasMany(u => u.Circles)
            .WithMany(c => c.Users)
            .UsingEntity<Dictionary<long, object>>(
                "CircleMemeber",
                r => r.HasOne<Circle>().WithMany().HasForeignKey("CircleId"),
                l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                je =>
                {
                    je.HasKey("UserId", "CircleId");
                    je.HasData(
                        new { UserId = 1L, CircleId = 1L },
                        new { UserId = 3L, CircleId = 1L },
                        new { UserId = 4L, CircleId = 1L },
                        new { UserId = 2L, CircleId = 2L },
                        new { UserId = 5L, CircleId = 2L },
                        new { UserId = 6L, CircleId = 2L },
                        new { UserId = 7L, CircleId = 2L },
                        new { UserId = 3L, CircleId = 3L },
                        new { UserId = 8L, CircleId = 3L });
                });


    }
}
