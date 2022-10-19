using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;

namespace VehicleInventory.Domain.CarItems;

public interface ICarItemsRepository
{
    Task<List<CarItem>> GetAllCarItemsPerCarModelAndCarItemType(Guid carModelId, Guid carItemTypeId);
}