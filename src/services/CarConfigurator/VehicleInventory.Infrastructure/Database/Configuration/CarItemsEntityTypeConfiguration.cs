using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;

namespace VehicleInventory.Infrastructure.Database.Configuration;


internal sealed class CarItemsEntityTypeConfiguration : IEntityTypeConfiguration<CarItem>
{
    public void Configure(EntityTypeBuilder<CarItem> builder)
    {
        builder.ToTable("CarItems");
            
        builder.HasKey(b => b.Id);

        builder.Property<string>("Name");
        builder.Property<string>("Description");

        builder.OwnsOne<MoneyValue>("Price", mv =>
        {
            mv.Property(p => p.Currency).HasColumnName("Currency");
            mv.Property(p => p.Value).HasColumnName("Value");
        });
        
        
        builder.Property<string>("PictureFileName");
        builder.Property<string>("PictureUri");
        builder.Property<int>("AvailableStock");
        builder.Property<int>("MaxStockThreshold");
        builder.Property<int>("RestockThreshold");
        builder.Property<bool>("OnReorder");
        
        builder.HasOne(ci => ci.CarModel)
            .WithMany()
            .HasForeignKey(ci => ci.CarModelId);
      
        builder.HasOne(ci => ci.CarItemType)
            .WithMany()
            .HasForeignKey(ci => ci.CarItemTypeId);

    }
}
