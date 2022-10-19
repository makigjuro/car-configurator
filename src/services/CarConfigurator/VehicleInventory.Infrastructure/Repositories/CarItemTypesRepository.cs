using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Infrastructure.Domain;

namespace VehicleInventory.Infrastructure.Repositories;

public class CarItemTypesRepository : ICarItemTypesRepository
{
    private readonly VehicleInventoryContext _context;

    public CarItemTypesRepository(VehicleInventoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<CarItemType>> GetAllCarItemTypes()
    {
        return await _context.CarItemTypes.ToListAsync();
    }
}