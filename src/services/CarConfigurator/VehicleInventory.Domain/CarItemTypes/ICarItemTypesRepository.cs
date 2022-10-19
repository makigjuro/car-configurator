namespace VehicleInventory.Domain.CarItemTypes;

public interface ICarItemTypesRepository
{
    Task<List<CarItemType>> GetAllCarItemTypes();
}