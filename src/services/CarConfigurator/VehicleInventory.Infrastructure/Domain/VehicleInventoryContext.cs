using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;

namespace VehicleInventory.Infrastructure.Domain;

public class VehicleInventoryContext : DbContext
{
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<CarItem> CarItems { get; set; }
    public DbSet<CarItemType> CarItemTypes { get; set; }

    public VehicleInventoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleInventoryContext).Assembly);
    }
}

public class VehicleInventoryContextDesignFactory : IDesignTimeDbContextFactory<VehicleInventoryContext>
{
    public VehicleInventoryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VehicleInventoryContext>()
            .UseSqlServer("Server=tcp:127.0.0.1,1433;Initial Catalog=VehicleInventory;User Id=sa;Password=Pass@word");

        return new VehicleInventoryContext(optionsBuilder.Options);
    }
}
