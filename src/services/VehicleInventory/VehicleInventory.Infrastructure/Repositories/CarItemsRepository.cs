using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Infrastructure.Domain;

namespace VehicleInventory.Infrastructure.Repositories;

public class CarItemsRepository : ICarItemsRepository
{
    private readonly VehicleInventoryContext _context;

    public CarItemsRepository(VehicleInventoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<CarItem>> GetAllCarItemsPerCarModelAndCarItemType(Guid carModelId, Guid carItemTypeId)
    {
        return await _context.CarItems
            .Where(x=> x.CarModelId == carModelId 
                       && x.CarItemTypeId == carItemTypeId
                       && x.AvailableStock > 0)
            .ToListAsync();
    }
}