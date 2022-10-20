using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarModels;

public class CarModelId : TypedIdValueBase
{
    public CarModelId(Guid value) : base(value)
    {
    }
}