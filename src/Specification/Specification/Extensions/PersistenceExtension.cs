using Microsoft.EntityFrameworkCore;
using Specification.Infrastructure.Persistence;

namespace Specification.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseInMemoryDatabase(databaseName: "InMemoryDb");
        }, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

        //using (var scope = services.BuildServiceProvider().CreateScope())
        //{
        //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //    context.Database.EnsureCreated();
        //}
        return services;
    }
}
