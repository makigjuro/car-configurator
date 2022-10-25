using Configurator.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Configurator.Domain.Repositories;

public interface IConfigurationsRepository
{
    Task<CarConfiguration?> GetByIdAsync(Guid configurationId);

    Task<CarConfiguration> AddAsync(CarConfiguration carConfiguration);
    Task<List<CarConfiguration>> GetAllAsync();
}