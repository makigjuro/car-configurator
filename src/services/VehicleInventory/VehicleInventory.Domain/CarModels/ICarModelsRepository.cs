using VehicleInventory.Domain.CarBrands;

namespace VehicleInventory.Domain.CarModels;

public interface ICarModelsRepository
{
    Task<List<CarModel>> GetAllCarModelsForBrand(Guid carBrandId);
}