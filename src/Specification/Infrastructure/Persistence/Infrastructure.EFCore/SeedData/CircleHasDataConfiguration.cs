using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.EFCore.SeedData;

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
            new Circle { Id = 1L, Name = "통기타", Created =  new DateTime(2023, 07, 07, 11, 12, 21) },
            new Circle { Id = 2L, Name = "축구" , Created =  new DateTime(2023, 08, 07, 11, 12, 21)},
            new Circle { Id = 3L, Name = "농구" , Created =  new DateTime(2024, 01, 07, 11, 12, 21)},
        };
    }
}

