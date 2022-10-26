using CarConfigurator.Framework.Configuration.Events;
using Configurator.Domain.Events;
using Configurator.Domain.Repositories;
using Configurator.Infrastructure.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Configurator.Application.EventHandlers;

public class PriceChangedEventHandler : INotificationHandler<ConfigurationPriceChangedEvent>
{
    private readonly IHubContext<ConfiguratorActionsHub> _hubContext;
    private readonly IConfigurationsRepository _configurationsRepository;

    public PriceChangedEventHandler(IHubContext<ConfiguratorActionsHub> hubContext, IConfigurationsRepository configurationsRepository)
    {
        _hubContext = hubContext;
        _configurationsRepository = configurationsRepository;
    }
    
    public async Task Handle(ConfigurationPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        var configuration = await _configurationsRepository.GetByIdAsync(notification.ConfigurationId);

        if (configuration != null)
        {
            decimal newPrice = configuration.CalculatePrice();
            await _hubContext
                .Clients
                .All.SendAsync(nameof(ConfigurationPriceChangedEvent), notification, cancellationToken);        }
    }
}