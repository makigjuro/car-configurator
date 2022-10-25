using CarConfigurator.Framework.Domain;

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
    }

    public void SetCarInterior(Interior interior)
    {
        Interior = interior;
    }

    public void SetColor(CarColor color)
    {
        Color = color;
    }
    
    public void SetRims(Rims rims)
    {
        Rims = rims;
    }
    
    public void AddExtraSet(CarExtra extra)
    {
        CarExtras.Add(extra);
    }

    public void SetCarModel(Model model)
    {
        Model = model;
    }
}