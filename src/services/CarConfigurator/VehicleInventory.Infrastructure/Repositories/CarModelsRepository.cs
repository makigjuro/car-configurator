using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Infrastructure.Domain;

namespace VehicleInventory.Infrastructure.Repositories;

public class CarModelsRepository : ICarModelsRepository
{
    private readonly VehicleInventoryContext _context;

    public CarModelsRepository(VehicleInventoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<CarModel>> GetAllCarModelsForBrand(Guid carBrandId)
    {
        return await _context.CarModels.Where(x => x.CarBrandId == carBrandId
                                                   && x.AvailableStock > 0).ToListAsync();
    }
}