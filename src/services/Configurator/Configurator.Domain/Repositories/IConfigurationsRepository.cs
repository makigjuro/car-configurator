using Configurator.Domain.Entities;

namespace Configurator.Domain.Repositories;

public interface IConfigurationsRepository
{
    Task<CarConfiguration> GetByIdAsync(Guid configurationId);

    Task<CarConfiguration> AddAsync(CarConfiguration carConfiguration);
}