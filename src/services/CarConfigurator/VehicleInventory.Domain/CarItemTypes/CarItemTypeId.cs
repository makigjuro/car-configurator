using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarItemTypes;

public class CarItemTypeId : TypedIdValueBase
{
    public CarItemTypeId(Guid value) : base(value)
    {
    }
}