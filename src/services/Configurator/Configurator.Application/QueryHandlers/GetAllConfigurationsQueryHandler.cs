using CarConfigurator.Framework.Configuration.Queries;
using Configurator.Application.Queries;
using Configurator.Application.Requests;
using Configurator.Domain.Repositories;

namespace Configurator.Application.QueryHandlers;

public class GetAllConfigurationsQueryHandler : IQueryHandler<GetAllConfigurationsQuery, List<ConfigurationDto>>
{
    private readonly IConfigurationsRepository _configurationsRepository;

    public GetAllConfigurationsQueryHandler(IConfigurationsRepository configurationsRepository)
    {
        _configurationsRepository = configurationsRepository;
    }
    public async Task<List<ConfigurationDto>> Handle(GetAllConfigurationsQuery request, CancellationToken cancellationToken)
    {
        var data = await _configurationsRepository.GetAllAsync();

        return data.Select(x => new ConfigurationDto()
        {
            ConfigurationId = x.Id,
            Name = x.Name
        }).ToList();
    }
}