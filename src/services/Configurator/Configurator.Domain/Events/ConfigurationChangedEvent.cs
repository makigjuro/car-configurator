using CarConfigurator.Framework.Domain;

namespace Configurator.Domain.Events;

public class ConfigurationChangedEvent : DomainEventBase
{
    public ConfigurationChangedEvent(Guid configurationId)
    {
        this.ConfigurationId = configurationId;
    }

    public Guid ConfigurationId { get; }
}
