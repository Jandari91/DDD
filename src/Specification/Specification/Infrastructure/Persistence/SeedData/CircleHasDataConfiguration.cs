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
        //var users = UserHasDataConfiguration.Users();
        return new List<Circle>()
        {
            new Circle { Id = 1L, Name = "통기타"
            },
            new Circle { Id = 2L, Name = "축구",
                Users = new List<User>()
            },
            new Circle { Id = 3L, Name = "농구",
                Users = new List<User>()
            },
        };
    }
}

