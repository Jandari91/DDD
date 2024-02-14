using Application.Mapper;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Testcontainers.PostgreSql;
using Xunit;

namespace Specification.Tests;

public class PostgresFactory<TProgram, TDbContext> :WebApplicationFactory<TProgram>, IAsyncLifetime
    where TProgram : class
    where TDbContext : DbContext
{
    public IContainer Container;
    public IMapper Mapper { get; set; } = default!;
    public PostgresFactory()
    {
        Container = new PostgreSqlBuilder().Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<TDbContext>();
            services.AddDbContextFactory<TDbContext>(option =>
            {
                var url = (Container as PostgreSqlContainer)!.GetConnectionString();
                option.UseNpgsql(url,
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });
            services.EnsureDbCreated<TDbContext>();
        });
    }

    public async Task InitializeAsync()
    {
        await Container.StartAsync();
        using var scope = Services.CreateScope();
        Mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    }

    public new async Task DisposeAsync() => await Container.DisposeAsync();
}

public static class TestExtensions
{
    public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
        if (descriptor != null) services.Remove(descriptor);
    }

    public static void EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
    {
        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var context = scopedServices.GetRequiredService<T>();
        context.Database.EnsureCreated();
        
    }
}
