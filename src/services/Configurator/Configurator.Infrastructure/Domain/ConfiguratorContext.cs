using Configurator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Configurator.Infrastructure.Domain;

public class ConfiguratorContext : DbContext
{
    public DbSet<CarConfiguration> CarConfigurations { get; set; }

    public ConfiguratorContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfiguratorContext).Assembly);
    }
}

public class ConfiguratorContextContextDesignFactory : IDesignTimeDbContextFactory<ConfiguratorContext>
{
    public ConfiguratorContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ConfiguratorContext>()
            .UseSqlServer("Server=tcp:127.0.0.1,1433;Initial Catalog=VehicleInventory;User Id=sa;Password=Pass@word");

        return new ConfiguratorContext(optionsBuilder.Options);
    }
}
