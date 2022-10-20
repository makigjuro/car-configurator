using VehicleInventory.Domain.CarModels;
using Xunit;

namespace VehicleInventory.Tests;

public class CarModelTests
{
    [Fact]
    public void AddingMoreQuantityOfCarModelThenMaximumQuantity()
    {
        var carModel = new CarModel()
        {
            Name = "ModelS",
            MaxStockThreshold = 5
        };

        carModel.AddStock(10);
        
        Assert.Equal(carModel.AvailableStock, carModel.MaxStockThreshold);
    }
}