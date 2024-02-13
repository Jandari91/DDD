using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Persistence.SeedData;

public static class CircleMemberHasDataConfiguration
{
    public static ModelBuilder HasDataCircleMember(this ModelBuilder builder)
    {
        builder.Entity<CircleUser>().HasData(CircleMember());
        return builder;
    }

    private static IEnumerable<CircleUser> CircleMember()
    {
        return new List<CircleUser>()
        {
            new CircleUser { UserId = 1, CircleId = 1},
            new CircleUser { UserId = 1, CircleId = 2},
        };
    }

    //private static IEnumerable<object> Memebers()
    //{
    //    return new List<User>()
    //    {
    //        new { Id = 1, Circles = { =1 } },
    //        new User{ Id = 2, Circles = new List<Circle>() { new Circle() {Id =1 }, new Circle() {Id =2 }, } },
    //    };
    //}
}
