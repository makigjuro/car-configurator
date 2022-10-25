using Autofac;
using Serilog;
using Serilog.Formatting.Compact;
using ILogger = Serilog.ILogger;

namespace Configurator.API;

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
