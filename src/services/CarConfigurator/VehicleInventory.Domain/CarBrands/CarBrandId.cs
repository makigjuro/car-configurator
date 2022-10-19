using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarBrands;

public class CarBrandId : TypedIdValueBase
{
    public CarBrandId(Guid value) : base(value)
    {
    }
}