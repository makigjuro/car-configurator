namespace VehicleInventory.Domain.CarBrands;

public interface ICarBrandsRepository
{
    Task<List<CarBrand>> GetAllCarBrands();
}