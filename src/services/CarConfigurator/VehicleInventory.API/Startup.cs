using Autofac;
using CarConfigurator.Framework;
using CarConfigurator.Framework.Configuration;
using CarConfigurator.Framework.Domain;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using Serilog.Formatting.Compact;
using VehicleInventory.Infrastructure;
using VehicleInventoryAPI.Configuration;
using ILogger = Serilog.ILogger;

namespace VehicleInventoryAPI;

public class Startup
{
    private readonly IConfiguration _configuration;

    private const string ConnectionString = "connectionString";

    private static ILogger _logger;
    
    public static IServiceProvider ConfigureServicesExtension(ContainerBuilder containerBuilder, 
        IServiceCollection services)
    {
        _logger = ConfigureLogger();
        _logger.Information("Logger configured");

        var _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        return ApplicationStartup.Initialize(
            containerBuilder,
            services,
            _configuration[ConnectionString],
            _logger,
            null);
    }
    
    private static ILogger ConfigureLogger()
    {
        return new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.RollingFile(new CompactJsonFormatter(), "logs/logs")
            .CreateLogger();
    }
}
