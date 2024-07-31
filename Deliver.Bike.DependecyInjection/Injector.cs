using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Entities.MotorcycleEntity.Repositories;
using Deliver.Bike.Domain.Entities.RentEntity.Repositories;
using Deliver.Bike.Domain.Shared.CalculateRentPrices;
using Deliver.Bike.Persistence.Context;
using Deliver.Bike.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace Deliver.Bike.DependencyInjection;
public static class Injector
{
   public static IServiceCollection AddServices(
       this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddLogging(x => x.AddSerilog());

        AddApplicationServices(services);
        AddPersistenceServices(services, configuration);

        return services;
    }

    private static void AddApplicationServices(IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(Application.AssemblyReference).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application.AssemblyReference).GetTypeInfo().Assembly));
        services.AddScoped<IMediator, Mediator>();
        services.AddValidatorsFromAssembly(applicationAssembly, includeInternalTypes: true);
    }

    private static void AddPersistenceServices(IServiceCollection services, IConfiguration configuration)
    {
        string? persistenceAssemblyName = typeof(Persistence.AssemblyReference).Assembly.GetName().Name;

        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.ConfigureWarnings(builder =>
            {
                builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
            });

            opt.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null);
            });
        });

        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<IDeliverManRepository, DeliveryManRepository>();
        services.AddScoped<IRentRepository, RentRepository>();

        services.AddScoped<ICalculateRentPrice, CalculateRentPrice>();

        services.AddScoped<ApplicationDbContext>();
    }
}
