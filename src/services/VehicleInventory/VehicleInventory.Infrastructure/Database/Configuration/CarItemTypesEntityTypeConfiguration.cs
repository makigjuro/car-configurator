using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItemTypes;

namespace VehicleInventory.Infrastructure.Database.Configuration;


internal sealed class CarItemTypesEntityTypeConfiguration : IEntityTypeConfiguration<CarItemType>
{
    public void Configure(EntityTypeBuilder<CarItemType> builder)
    {
        builder.ToTable("CarItemTypes");
            
        builder.HasKey(b => b.Id);

        builder.Property<string>("Name");
    }
}
