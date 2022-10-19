using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Infrastructure.Domain;

namespace VehicleInventory.Infrastructure.Repositories;

public class CarBrandsRepository : ICarBrandsRepository
{
    private readonly VehicleInventoryContext _context;

    public CarBrandsRepository(VehicleInventoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<List<CarBrand>> GetAllCarBrands()
    {
        return await _context.CarBrands.ToListAsync();
    }
}

