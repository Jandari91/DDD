using Microsoft.EntityFrameworkCore;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Persistence.SeedData;

public static class CircleHasDataConfiguration
{
    public static ModelBuilder HasDataCircle(this ModelBuilder builder)
    {
        builder.Entity<Circle>().HasData(Circles());
        return builder;
    }

    private static IEnumerable<Circle> Circles()
    {
        var users = UserHasDataConfiguration.Users();
        return new List<Circle>()
        {
            new Circle { Id = 1, Name = "통기타",
                Users = new List<User>(users)
            },
            new Circle { Id = 2, Name = "축구",
                Users = new List<User>(users.Take(6))
            },
            new Circle { Id = 3, Name = "농구",
                Users = new List<User>(users.Skip(2).Take(6))
            },
        };
    }
}

