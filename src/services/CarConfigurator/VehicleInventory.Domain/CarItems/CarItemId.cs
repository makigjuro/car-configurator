using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarItems;

public class CarItemId : TypedIdValueBase
{
    public CarItemId(Guid value) : base(value)
    {
    }
}
