using CarConfigurator.Framework.Domain;

namespace VehicleInventory.Domain.CarItemTypes;

public class CarItemType : Entity, IAggregateRoot
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
}