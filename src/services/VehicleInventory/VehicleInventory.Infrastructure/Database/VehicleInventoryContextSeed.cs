using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;
using VehicleInventory.Infrastructure.Domain;

public class VehicleInventoryContextSeed {

    public void Seed(VehicleInventoryContext context)
    {
        var teslaBrand = SeedCarBrands(context);
        
        var carItemTypes = SeedCarItemTypes(context);
        
        SeedCarModelS(context, teslaBrand, carItemTypes);

        SeedCarModelX(context, teslaBrand, carItemTypes);

        SeedCarModelY(context, teslaBrand, carItemTypes);

        var allCars = context.CarModels.ToList();
        
        foreach (var carModel in allCars)
        {
            carModel.MaxStockThreshold = 5;
            carModel.AddStock(5);
            context.CarModels.Update(carModel);
        }
        
        var allItems = context.CarItems.ToList();

        foreach (var carItem in allItems)
        {
            carItem.MaxStockThreshold = 5;
            carItem.AddStock(5);
            context.CarItems.Update(carItem);
        }
        
        context.SaveChanges();
    }

    private CarBrand SeedCarBrands(VehicleInventoryContext context)
    {
        var teslaBrand = new CarBrand(Guid.NewGuid(), "Tesla");
        
        if (!context.CarBrands.Any())
        {
            context.CarBrands.Add(teslaBrand);
        }

        return teslaBrand;
    }
    
    private void SeedCarModelS(VehicleInventoryContext context, CarBrand carBrand, List<CarItemType> carItemTypes)
    {
        var modelS = new CarModel()
        {
            Id = new Guid(),
            Name = "Model S",
            CarBrand = carBrand,
            Price = MoneyValue.Of(50000, "€"),
            PictureFileName = "model_s_white_wheel_1.png"
        };

        if (!context.CarModels.Any(x => x.Name == modelS.Name))
        {
            context.CarModels.Add(modelS);
        }
        
        var carEnginePowerType = carItemTypes.FirstOrDefault(x => x.Name == "CarEnginePowerType");
        var carColorType = carItemTypes.FirstOrDefault(x => x.Name == "CarColorType");

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
        
        var modelsColor1 = new CarItem()
        {
            Id = new Guid(),
            Name = "Pearl White Multi-Coat",
            IsIncluded = true,
            PictureFileName = "model_s_white_wheel_1.png",
            CarItemType = carColorType, 
            CarModel = modelS 
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
        
        var carRimsType = carItemTypes.FirstOrDefault(x => x.Name == "CarRimsType");

        var carRims19 = new CarItem()
        {
            Id = new Guid(),
            Name = "19\"\" Tempest Wheels",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carRimsType,
            CarModel = modelS,
            PictureFileName = "model_s_wheel_1.png"
        };
        
        var carRims21 = new CarItem()
        {
            Id = new Guid(),
            Name = "21\"\" Sonic Carbon Twin Turbine Wheels",
            IsIncluded = false,
            Price = MoneyValue.Of(3300, "€"),
            CarItemType = carRimsType,
            CarModel = modelS 
        };
        
        var carInteriorType = carItemTypes.FirstOrDefault(x => x.Name == "CarInteriorType");

        var carInteriorOne = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carInteriorType,
            CarModel = modelS 
        };

        var carInteriorTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelS 
        };
        
        var carInteriorThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Cream Oak Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelS 
        };


        var carExtraType = carItemTypes.FirstOrDefault(x => x.Name == "CarExtraType");
        
        var carExtraOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Sound System",
            IsIncluded = false,
            Price = MoneyValue.Of(750, "€"),
            CarItemType = carExtraType,
            CarModel = modelS 
        };
        
        var carExtraTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Auto Pilot System",
            IsIncluded = false,
            Price = MoneyValue.Of(1750, "€"),
            CarItemType = carExtraType,
            CarModel = modelS 
        };
        
        var carExtraThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Seat Heaters",
            IsIncluded = false,
            Price = MoneyValue.Of(650, "€"),
            CarItemType = carExtraType,
            CarModel = modelS 
        };
        
        var carExtraFour = new CarItem()
        {
            Id = new Guid(),
            Name = "Visible Roof",
            IsIncluded = false,
            Price = MoneyValue.Of(5650, "€"),
            CarItemType = carExtraType,
            CarModel = modelS 
        };
        
        var carExtraFive = new CarItem()
        {
            Id = new Guid(),
            Name = "Faster Charger",
            IsIncluded = false,
            Price = MoneyValue.Of(3650, "€"),
            CarItemType = carExtraType,
            CarModel = modelS 
        };

        if (!context.CarItems.Any())
        {
            context.CarItems.Add(modelsColor1);
            context.CarItems.Add(modelsColor2);
            context.CarItems.Add(modelsColor3);
            context.CarItems.Add(modelsColor4);
            context.CarItems.Add(modelsColor5);
            
            context.CarItems.Add(modelSEngineOne);
            context.CarItems.Add(modelSEngineTwo);
            
            context.CarItems.Add(carRims19);
            context.CarItems.Add(carRims21);

            context.CarItems.Add(carInteriorOne);
            context.CarItems.Add(carInteriorTwo);
            context.CarItems.Add(carInteriorThree);

            context.CarItems.Add(carExtraOne);
            context.CarItems.Add(carExtraTwo);
            context.CarItems.Add(carExtraThree);
            context.CarItems.Add(carExtraFour);
            context.CarItems.Add(carExtraFive);
        }
    }
    
    private void SeedCarModelX(VehicleInventoryContext context, CarBrand carBrand, List<CarItemType> carItemTypes)
    {
        var modelX = new CarModel()
        {
            Id = new Guid(),
            Name = "Model X",
            CarBrand = carBrand,
            Price = MoneyValue.Of(65000, "€"),
            PictureFileName = "model_x_white_wheel_1.png"
        };
        
        if (!context.CarModels.Any(x => x.Name == modelX.Name))
        {
            context.CarModels.Add(modelX);
        }
        
        var carEnginePowerType = carItemTypes.FirstOrDefault(x => x.Name == "CarEnginePowerType");
        var carColorType = carItemTypes.FirstOrDefault(x => x.Name == "CarColorType");
        
        var modelSEngineOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Long Range Engine",
            IsIncluded = true,
            CarItemType = carEnginePowerType, 
            CarModel = modelX,
            Description = "Quicker acceleration: 0-60 kmh in 2.3s"
        };

        var modelSEngineTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Performance",
            IsIncluded = false,
            CarItemType = carEnginePowerType, 
            CarModel = modelX,
            Price = MoneyValue.Of(25000, "€"),
            Description = "Quickest 0-60 kmh and quarter mile acceleration of any production car ever"
        };
        
        var modelsColor1 = new CarItem()
        {
            Id = new Guid(),
            Name = "Pearl White Multi-Coat",
            IsIncluded = true,
            PictureFileName = "model_x_white_wheel_1.png",
            CarItemType = carColorType, 
            CarModel = modelX 
        };

        var modelsColor2 = new CarItem()
        {
            Id = new Guid(),
            Name = "Solid Black",
            IsIncluded = false,
            PictureFileName = "model_x_black_wheel_1.png",
            Price = MoneyValue.Of(1000, "€"),
            CarItemType = carColorType,
            CarModel = modelX 
            
        };
        
        var modelsColor3 = new CarItem()
        {
            Id = new Guid(),
            Name = "Midnight Silver Metallic",
            IsIncluded = false,
            PictureFileName = "model_x_silver_wheel_1.png",
            Price = MoneyValue.Of(1100, "€"),
            CarItemType = carColorType,
            CarModel = modelX 
        };
        
        var modelsColor4 = new CarItem()
        {
            Id = new Guid(),
            Name = "Deep Blue Metallic",
            IsIncluded = false,
            PictureFileName = "model_x_blue_wheel_1.png",
            Price = MoneyValue.Of(1200, "€"),
            CarItemType = carColorType,
            CarModel = modelX 
        };
        
        var modelsColor5 = new CarItem()
        {
            Id = new Guid(),
                Name = "Red Multi-Coat",
            IsIncluded = false,
            PictureFileName = "model_x_red_wheel_1.png",
            Price = MoneyValue.Of(1300, "€"),
            CarItemType = carColorType,
            CarModel = modelX 
        };
        
        var carRimsType = carItemTypes.FirstOrDefault(x => x.Name == "CarRimsType");

        var carRims19 = new CarItem()
        {
            Id = new Guid(),
            Name = "20\"\" Silver Wheels",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carRimsType,
            CarModel = modelX 
        };
        
        var carRims21 = new CarItem()
        {
            Id = new Guid(),
            Name = "22\"\" Onyx Black Wheels",
            IsIncluded = false,
            Price = MoneyValue.Of(3300, "€"),
            CarItemType = carRimsType,
            CarModel = modelX 
        };

        var carInteriorType = carItemTypes.FirstOrDefault(x => x.Name == "CarInteriorType");
        
        var carInteriorOne = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carInteriorType,
            CarModel = modelX 
        };

        var carInteriorTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelX 
        };
        
        var carInteriorThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Cream Oak Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelX 
        };
        
        var carExtraType = carItemTypes.FirstOrDefault(x => x.Name == "CarExtraType");
        
        var carExtraOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Sound System",
            IsIncluded = false,
            Price = MoneyValue.Of(750, "€"),
            CarItemType = carExtraType,
            CarModel = modelX 
        };
        
        var carExtraTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Auto Pilot System",
            IsIncluded = false,
            Price = MoneyValue.Of(1750, "€"),
            CarItemType = carExtraType,
            CarModel = modelX 
        };
        
        var carExtraThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Seat Heaters",
            IsIncluded = false,
            Price = MoneyValue.Of(650, "€"),
            CarItemType = carExtraType,
            CarModel = modelX 
        };
        
        var carExtraFour = new CarItem()
        {
            Id = new Guid(),
            Name = "Visible Roof",
            IsIncluded = false,
            Price = MoneyValue.Of(5650, "€"),
            CarItemType = carExtraType,
            CarModel = modelX 
        };
        
        var carExtraFive = new CarItem()
        {
            Id = new Guid(),
            Name = "Faster Charger",
            IsIncluded = false,
            Price = MoneyValue.Of(3650, "€"),
            CarItemType = carExtraType,
            CarModel = modelX 
        };

        if (!context.CarItems.Any())
        {
            context.CarItems.Add(modelsColor1);
            context.CarItems.Add(modelsColor2);
            context.CarItems.Add(modelsColor3);
            context.CarItems.Add(modelsColor4);
            context.CarItems.Add(modelsColor5);
            
            context.CarItems.Add(modelSEngineOne);
            context.CarItems.Add(modelSEngineTwo);
            
            context.CarItems.Add(carRims19);
            context.CarItems.Add(carRims21);
            
            context.CarItems.Add(carInteriorOne);
            context.CarItems.Add(carInteriorTwo);
            context.CarItems.Add(carInteriorThree);
            
            context.CarItems.Add(carExtraOne);
            context.CarItems.Add(carExtraTwo);
            context.CarItems.Add(carExtraThree);
            context.CarItems.Add(carExtraFour);
            context.CarItems.Add(carExtraFive);
        }
    }
    
    private void SeedCarModelY(VehicleInventoryContext context, CarBrand carBrand, List<CarItemType> carItemTypes)
    {
        var modelY = new CarModel()
        {
            Id = new Guid(),
            Name = "Model Y",
            CarBrand = carBrand,
            Price = MoneyValue.Of(72000, "€"),
            PictureFileName = "model_y_white_wheel_1.png"

        };
        
        var carEnginePowerType = carItemTypes.FirstOrDefault(x => x.Name == "CarEnginePowerType");
        var carColorType = carItemTypes.FirstOrDefault(x => x.Name == "CarColorType");

        var modelYEngineOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Long Range Engine",
            IsIncluded = true,
            CarItemType = carEnginePowerType, 
            CarModel = modelY,
            Description = "Quicker acceleration: 0-60 kmh in 2.3s"
        };

        var modelYEngineTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Performance",
            IsIncluded = false,
            CarItemType = carEnginePowerType, 
            CarModel = modelY,
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
        
        var carRimsType = carItemTypes.FirstOrDefault(x => x.Name == "CarRimsType");

        var carRims19 = new CarItem()
        {
            Id = new Guid(),
            Name = "20\"\" Silver Wheels",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carRimsType,
            CarModel = modelY 
        };
        
        var carRims21 = new CarItem()
        {
            Id = new Guid(),
            Name = "22\"\" Onyx Black Wheels",
            IsIncluded = false,
            Price = MoneyValue.Of(3300, "€"),
            CarItemType = carRimsType,
            CarModel = modelY 
        };
        
        var carInteriorType = carItemTypes.FirstOrDefault(x => x.Name == "CarInteriorType");
        
        var carInteriorOne = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = true,
            Price = MoneyValue.Of(0, "€"),
            CarItemType = carInteriorType,
            CarModel = modelY 
        };

        var carInteriorTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "All black Figured Ash Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelY 
        };
        
        var carInteriorThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Cream Oak Wood Décor",
            IsIncluded = false,
            Price = MoneyValue.Of(1500, "€"),
            CarItemType = carInteriorType,
            CarModel = modelY 
        };

        var carExtraType = carItemTypes.FirstOrDefault(x => x.Name == "CarExtraType");
        
        var carExtraOne = new CarItem()
        {
            Id = new Guid(),
            Name = "Sound System",
            IsIncluded = false,
            Price = MoneyValue.Of(750, "€"),
            CarItemType = carExtraType,
            CarModel = modelY 
        };
        
        var carExtraTwo = new CarItem()
        {
            Id = new Guid(),
            Name = "Auto Pilot System",
            IsIncluded = false,
            Price = MoneyValue.Of(1750, "€"),
            CarItemType = carExtraType,
            CarModel = modelY 
        };
        
        var carExtraThree = new CarItem()
        {
            Id = new Guid(),
            Name = "Seat Heaters",
            IsIncluded = false,
            Price = MoneyValue.Of(650, "€"),
            CarItemType = carExtraType,
            CarModel = modelY 
        };
        
        var carExtraFour = new CarItem()
        {
            Id = new Guid(),
            Name = "Visible Roof",
            IsIncluded = false,
            Price = MoneyValue.Of(5650, "€"),
            CarItemType = carExtraType,
            CarModel = modelY 
        };
        
        var carExtraFive = new CarItem()
        {
            Id = new Guid(),
            Name = "Faster Charger",
            IsIncluded = false,
            Price = MoneyValue.Of(3650, "€"),
            CarItemType = carExtraType,
            CarModel = modelY 
        };

        
        if (!context.CarItems.Any())
        {
            context.CarItems.Add(modelsYColor1);
            context.CarItems.Add(modelsYColor2);
            context.CarItems.Add(modelsYColor3);
            context.CarItems.Add(modelsYColor4);
            context.CarItems.Add(modelsYColor5);
            
            context.CarItems.Add(modelYEngineOne);
            context.CarItems.Add(modelYEngineTwo);
            
            context.CarItems.Add(carRims19);
            context.CarItems.Add(carRims21);
            
            context.CarItems.Add(carInteriorOne);
            context.CarItems.Add(carInteriorTwo);
            context.CarItems.Add(carInteriorThree);
            
            context.CarItems.Add(carExtraOne);
            context.CarItems.Add(carExtraTwo);
            context.CarItems.Add(carExtraThree);
            context.CarItems.Add(carExtraFour);
            context.CarItems.Add(carExtraFive);
        }

        if (!context.CarModels.Any(x => x.Name == modelY.Name))
        {
            context.CarModels.Add(modelY);
        }

    }
    
    private List<CarItemType> SeedCarItemTypes(VehicleInventoryContext context)
    {
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

        return new List<CarItemType>()
        {
            carEnginePowerType,
            carRimsType,
            carColorType,
            carInteriorType,
            carExtraType
        };
    }
    
}