using CarConfigurator.Framework.Domain;

namespace Configurator.Domain.Events;

public class ConfigurationPriceChangedEvent : DomainEventBase
{
    public ConfigurationPriceChangedEvent(Guid configurationId, decimal price)
    {
        ConfigurationId = configurationId;
        Price = price;
    }

    public Guid ConfigurationId { get; }
    public decimal Price { get; }
}
