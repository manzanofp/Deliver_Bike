using Deliver.Bike.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deliver.Bike.Persistence.StartupService;

public class EntityFrameworkCoreMigrator
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMigrator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task Migrate()
    {
        var env = _serviceProvider.GetRequiredService<IWebHostEnvironment>();

        if (env.EnvironmentName is "Development")
            return;
        
        using var serviceScope = _serviceProvider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
    }
}
