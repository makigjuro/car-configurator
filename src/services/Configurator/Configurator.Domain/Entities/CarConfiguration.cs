using CarConfigurator.Framework.Domain;
using Configurator.Domain.Events;

namespace Configurator.Domain.Entities;

public class CarConfiguration : Entity, IAggregateRoot
{
    public CarConfiguration()
    {
        CarExtras = new List<CarExtra>();
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid BrandId { get; set; }
    
    public Model Model { get; set; }

    public CarColor Color { get; set; }

    public Engine Engine { get; set; }

    public Interior Interior { get; set; }
    public List<CarExtra> CarExtras { get; set; }
    
    public Rims Rims { get; set; }

    public void SetCarEngine(Engine engine)
    {
        Engine = engine;
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));
    }

    public void SetCarInterior(Interior interior)
    {
        Interior = interior;
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));
    }

    public void SetColor(CarColor color)
    {
        Color = color;
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));
    }
    
    public void SetRims(Rims rims)
    {
        Rims = rims;
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));
    }
    
    public void AddExtraSet(CarExtra extra)
    {
        CarExtras.Add(extra);
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));

    }

    public void SetCarModel(Model model)
    {
        Model = model;
        this.AddDomainEvent(new ConfigurationChangedEvent(Id));
    }

    public decimal CalculatePrice()
    {
        return Model.Price + Engine.Price + Color.Price + Rims.Price + Interior.Price + CarExtras.Sum(extra => extra.Price);
    }
}