using Autofac;
using Autofac.Extensions.DependencyInjection;
using CarConfigurator.Framework.Configuration;
using CarConfigurator.Framework.Logging;
using CarConfigurator.Framework.Processing;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using VehicleInventory.Infrastructure.Database;

namespace VehicleInventory.Infrastructure;

public class ApplicationStartup
{
    public static IServiceProvider Initialize(
        ContainerBuilder containerBuilder,
        IServiceCollection services,
        string connectionString,
        ILogger logger,
        IExecutionContextAccessor executionContextAccessor)
    {
        var serviceProvider = CreateAutofacServiceProvider(
            containerBuilder,
            services, 
            connectionString, 
            logger,
            executionContextAccessor);

        return serviceProvider;
    }
    
    private static IServiceProvider CreateAutofacServiceProvider(
        ContainerBuilder container,
        IServiceCollection services,
        string connectionString,
        ILogger logger,
        IExecutionContextAccessor executionContextAccessor)
    {
        
        container.RegisterModule(new LoggingModule(logger));
        container.RegisterModule(new DataAccessModule(connectionString));
        container.RegisterModule(new MediatorModule(typeof(Application.CarBrands.GetCarBrandsQuery).Assembly));
        
        return null;
    }
    
    
}