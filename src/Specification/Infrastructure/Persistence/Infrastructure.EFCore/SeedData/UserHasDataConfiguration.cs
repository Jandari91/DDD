using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.EFCore.SeedData;

public static class UserHasDataConfiguration
{
    public static ModelBuilder HasDataUser(this ModelBuilder builder)
    {
        builder.Entity<User>().HasData(Users());
        return builder;
    }

    public static IEnumerable<User> Users()
    {
        return new List<User>()
        {
            new User { Id = 1L, Name = "박", Age=20, Email="박@email.com", IsPremium = true},
            new User { Id = 2L, Name = "조", Age=21, Email="조@email.com", IsPremium = true },
            new User { Id = 3L, Name = "김", Age=22, Email="김@email.com", IsPremium = false },
            new User { Id = 4L, Name = "이", Age=23, Email="이@email.com", IsPremium = false },
            new User { Id = 5L, Name = "도", Age=24, Email="도@email.com", IsPremium = false },
            new User { Id = 6L, Name = "최", Age=24, Email="최@email.com", IsPremium = false },
            new User { Id = 7L, Name = "백", Age=24, Email="백@email.com", IsPremium = false },
            new User { Id = 8L, Name = "노", Age=24, Email="노@email.com", IsPremium = false },
            new User { Id = 9L, Name = "남", Age=24, Email="남@email.com", IsPremium = false },
            new User { Id = 10L, Name = "송", Age=24, Email="송@email.com", IsPremium = false },
        };
    }
}

