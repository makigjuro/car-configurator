using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarBrands;

public class CarBrand : Entity, IAggregateRoot
{
    public CarBrand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }
}