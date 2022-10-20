using CarConfigurator.Framework.Database;

namespace VehicleInventory.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly VehicleInventoryContext _vehicleInventoryContext;

    public UnitOfWork(VehicleInventoryContext vehicleInventoryContext)
    {
        _vehicleInventoryContext = vehicleInventoryContext;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await this._vehicleInventoryContext.SaveChangesAsync(cancellationToken);
    }
}
