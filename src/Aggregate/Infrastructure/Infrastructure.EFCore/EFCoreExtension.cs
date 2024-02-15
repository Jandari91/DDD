using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;

namespace Infrastructure.EFCore;

public static class EFCoreExtension
{
    public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration, string assemblyName)
    {
        services.AddDbContextFactory<ApplicationDbContext>(option =>
        {
            var url = configuration.GetSection("Postgres").Value ?? configuration.GetConnectionString("Postgres");
            option.UseNpgsql(url,
                b => b.MigrationsAssembly(assemblyName)).LogTo(Console.WriteLine, LogLevel.Information);
        });
        return services;
    }

    public static IServiceCollection AddInMemory(this IServiceCollection services, string assemblyName)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseInMemoryDatabase(assemblyName).LogTo(Console.WriteLine, LogLevel.Information);
        });
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }
        return services;
    }
}
