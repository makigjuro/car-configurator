using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInventory.Domain.CarBrands;

namespace VehicleInventory.Infrastructure.Database.Configuration;

internal sealed class CarBrandEntityTypeConfiguration : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.ToTable("CarBrands");
            
        builder.HasKey(b => b.Id);

        builder.Property<string>("Name");
    }
}
