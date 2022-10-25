using CarConfigurator.Framework.Domain;

namespace Configurator.Domain.Entities;

public class CarExtra : Entity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; } 
    
    public string PictureUrl { get; set; }

}