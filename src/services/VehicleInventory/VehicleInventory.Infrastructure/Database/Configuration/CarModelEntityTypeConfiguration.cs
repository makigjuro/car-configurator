using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;

namespace VehicleInventory.Infrastructure.Database.Configuration;

public class CarModelEntityTypeConfiguration :IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("CarModels");
            
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
        
        builder.HasOne(ci => ci.CarBrand)
            .WithMany()
            .HasForeignKey(ci => ci.CarBrandId);


    }
}

