using Autofac;
using CarConfigurator.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;
using VehicleInventory.Infrastructure.Domain;
using VehicleInventory.Infrastructure.Repositories;

namespace VehicleInventory.Infrastructure.Database;

public class DataAccessModule : Autofac.Module
{
    private readonly string _databaseConnectionString;

    public DataAccessModule(string databaseConnectionString)
    {
        this._databaseConnectionString = databaseConnectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarBrandsRepository>()
            .As<ICarBrandsRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CarModelsRepository>()
            .As<ICarModelsRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarItemsRepository>()
            .As<ICarItemsRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarItemTypesRepository>()
            .As<ICarItemTypesRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StronglyTypedIdValueConverterSelector>()
            .As<IValueConverterSelector>()
            .SingleInstance();

        builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<VehicleInventoryContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                var context =  new VehicleInventoryContext(dbContextOptionsBuilder.Options);
                
                context.Database.Migrate();
                
                Seed(context);
                
                return context;
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }

    private void Seed(VehicleInventoryContext context)
    {
        var teslaBrand = new CarBrand(Guid.NewGuid(), "Tesla");
        
        if (!context.CarBrands.Any())
        {
            context.CarBrands.Add(teslaBrand);
        }

        var carEnginePowerType = new CarItemType()
        {
            Id = new Guid(),
            Name = "CarEnginePowerType"
        };
        
        var carRimsType = new CarItemType()
        {
            Id = new Guid(),
            Name = "CarRimsType"
        };
        
        var carColorType = new CarItemType()
        {
            Id = new Guid(),
            Name = "CarColorType"
        };
        
        var carInteriorType = new CarItemType()
        {
            Id = new Guid(),
            Name = "CarInteriorType"
        };
        
        var carExtraType = new CarItemType()
        {
            Id = new Guid(),
            Name = "CarExtraType"
        };
        
        if (!context.CarItemTypes.Any())
        {
            context.CarItemTypes.Add(carEnginePowerType);
            context.CarItemTypes.Add(carRimsType);
            context.CarItemTypes.Add(carColorType);
            context.CarItemTypes.Add(carInteriorType);
            context.CarItemTypes.Add(carExtraType);
        }
        
        var modelS = new CarModel()
        {
            Id = new Guid(),
            Name = "Model S",
            CarBrand = teslaBrand,
            Price = MoneyValue.Of(50000, "€"),
            PictureFileName = "model_s_white_wheel_1.png"
        };

        var modelsColor1 = new CarItem()
        {
            Id = new Guid(),
            Name = "Pearl White Multi-Coat",
            IsIncluded = true,
            PictureFileName = "model_s_white_wheel_1.png",
            CarItemType = carColorType
            , CarModel = modelS 
        };
        
        var modelSEngineOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Long Range Engine",
            IsIncluded = true,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Description = "Quicker acceleration: 0-60 kmh in 2.3s"
        };

        var modelSEngineTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Performance",
            IsIncluded = false,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Price = MoneyValue.Of(25000, "€"),
            Description = "Quickest 0-60 kmh and quarter mile acceleration of any production car ever"
        };


        
        var modelsColor2 = new CarItem()
        {
            Id = new Guid(),
            Name = "Solid Black",
            IsIncluded = false,
            PictureFileName = "model_s_black_wheel_1.png",
            Price = MoneyValue.Of(1000, "€"),
            CarItemType = carColorType,
            CarModel = modelS 
            
        };
        
        var modelsColor3 = new CarItem()
        {
            Id = new Guid(),
            Name = "Midnight Silver Metallic",
            IsIncluded = false,
            PictureFileName = "model_s_silver_wheel_1.png",
            Price = MoneyValue.Of(1100, "€"),
            CarItemType = carColorType,
            CarModel = modelS 
        };
        
        var modelsColor4 = new CarItem()
        {
            Id = new Guid(),
            Name = "Deep Blue Metallic",
            IsIncluded = false,
            PictureFileName = "model_s_blue_wheel_1.png",
            Price = MoneyValue.Of(1200, "€"),
            CarItemType = carColorType,
            CarModel = modelS 
        };
        
        var modelsColor5 = new CarItem()
        {
            Id = new Guid(),
            Name = "Red Multi-Coat",
            IsIncluded = false,
            PictureFileName = "model_s_red_wheel_1.png",
            Price = MoneyValue.Of(1300, "€"),
            CarItemType = carColorType,
            CarModel = modelS 
        };
        
        var modelX = new CarModel()
        {
            Id = new Guid(),
            Name = "Model X",
            CarBrand = teslaBrand,
            Price = MoneyValue.Of(65000, "€"),
            PictureFileName = "model_x_white_wheel_1.png"

        };
        
        
        var modelXEngineOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Long Range Engine",
            IsIncluded = true,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Description = "Quicker acceleration: 0-60 kmh in 2.3s"
        };

        var modelXEngineTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Performance",
            IsIncluded = false,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Price = MoneyValue.Of(25000, "€"),
            Description = "Quickest 0-60 kmh and quarter mile acceleration of any production car ever"
        };
        
        var modelsXColor1 = new CarItem()
        {
            Id = new Guid(),
            Name = "Pearl White Multi-Coat",
            IsIncluded = true,
            PictureFileName = "model_x_white_wheel_1.png",
            CarItemType = carColorType,
            CarModel = modelX 
        };
        
        var modelsXColor2 = new CarItem()
        {
            Id = new Guid(),
            Name = "Solid Black",
            IsIncluded = false,
            PictureFileName = "model_x_black_wheel_1.png",
            Price = MoneyValue.Of(1000, "€"),
            CarItemType = carColorType,
            CarModel = modelX 

        };
        
        var modelsXColor3 = new CarItem()
        {
            Id = new Guid(),
            Name = "Midnight Silver Metallic",
            IsIncluded = false,
            PictureFileName = "model_x_silver_wheel_1.png",
            Price = MoneyValue.Of(1100, "€"),
            CarItemType = carColorType,
            CarModel = modelX 

        };
        
        var modelsXColor4 = new CarItem()
        {
            Id = new Guid(),
            Name = "Deep Blue Metallic",
            IsIncluded = false,
            PictureFileName = "model_x_blue_wheel_1.png",
            Price = MoneyValue.Of(1200, "€"),
            CarItemType = carColorType,
            CarModel = modelX
        };
        
        var modelsXColor5 = new CarItem()
        {
            Id = new Guid(),
            Name = "Red Multi-Coat",
            IsIncluded = false,
            PictureFileName = "model_x_red_wheel_1.png",
            Price = MoneyValue.Of(1300, "€"),
            CarItemType = carColorType,
            CarModel = modelX 

        };
        
        var modelY = new CarModel()
        {
            Id = new Guid(),
            Name = "Model Y",
            CarBrand = teslaBrand,
            Price = MoneyValue.Of(72000, "€"),
            PictureFileName = "model_y_white_wheel_1.png"

        };
        
        var modelYEngineOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Long Range Engine",
            IsIncluded = true,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Description = "Quicker acceleration: 0-60 kmh in 2.3s"
        };

        var modelYEngineTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Performance",
            IsIncluded = false,
            CarItemType = carEnginePowerType, 
            CarModel = modelS,
            Price = MoneyValue.Of(25000, "€"),
            Description = "Quickest 0-60 kmh and quarter mile acceleration of any production car ever"
        };

        
        var modelsYColor1 = new CarItem()
        {
            Id = new Guid(),
            Name = "Pearl White Multi-Coat",
            IsIncluded = true,
            PictureFileName = "model_y_white_wheel_1.png",
            CarItemType = carColorType,
            CarModel = modelY

        };
        
        var modelsYColor2 = new CarItem()
        {
            Id = new Guid(),
            Name = "Solid Black",
            IsIncluded = false,
            PictureFileName = "model_y_black_wheel_1.png",
            Price = MoneyValue.Of(1000, "€"),
            CarItemType = carColorType,
            CarModel = modelY

        };
        
        var modelsYColor3 = new CarItem()
        {
            Id = new Guid(),
            Name = "Midnight Silver Metallic",
            IsIncluded = false,
            PictureFileName = "model_y_silver_wheel_1.png",
            Price = MoneyValue.Of(1100, "€"),
            CarItemType = carColorType,
            CarModel = modelY

        };
        
        var modelsYColor4 = new CarItem()
        {
            Id = new Guid(),
            Name = "Deep Blue Metallic",
            IsIncluded = false,
            PictureFileName = "model_y_blue_wheel_1.png",
            Price = MoneyValue.Of(1200, "€"),
            CarItemType = carColorType,
            CarModel = modelY
        };
        
        var modelsYColor5 = new CarItem()
        {
            Id = new Guid(),
            Name = "Red Multi-Coat",
            IsIncluded = false,
            PictureFileName = "model_y_red_wheel_1.png",
            Price = MoneyValue.Of(1300, "€"),
            CarItemType = carColorType,
            CarModel = modelY
        };
        
        if (!context.CarItems.Any())
        {
            context.CarItems.Add(modelsColor1);
            context.CarItems.Add(modelsColor2);
            context.CarItems.Add(modelsColor3);
            context.CarItems.Add(modelsColor4);
            context.CarItems.Add(modelsColor5);

            context.CarItems.Add(modelsXColor1);
            context.CarItems.Add(modelsXColor2);
            context.CarItems.Add(modelsXColor3);
            context.CarItems.Add(modelsXColor4);
            context.CarItems.Add(modelsXColor5);

            context.CarItems.Add(modelsYColor1);
            context.CarItems.Add(modelsYColor2);
            context.CarItems.Add(modelsYColor3);
            context.CarItems.Add(modelsYColor4);
            context.CarItems.Add(modelsYColor5);
            
            context.CarItems.Add(modelXEngineOne);
            context.CarItems.Add(modelXEngineTwo);
            context.CarItems.Add(modelYEngineOne);
            context.CarItems.Add(modelYEngineTwo);
            
            context.CarItems.Add(modelSEngineOne);
            context.CarItems.Add(modelSEngineTwo);
        }



        if (!context.CarModels.Any())
        {
            context.CarModels.Add(modelS);
            context.CarModels.Add(modelX);
            context.CarModels.Add(modelY);
        }

        context.SaveChanges();
    }
}
