using Configurator.Domain.Entities;
using Configurator.Domain.Repositories;
using Configurator.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Configurator.Infrastructure.Repositories;

public class ConfigurationsRepository : IConfigurationsRepository
{
    private readonly ConfiguratorContext _context;

    public ConfigurationsRepository(ConfiguratorContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CarConfiguration?> GetByIdAsync(Guid configurationId)
    {
        return await _context.CarConfigurations.FirstOrDefaultAsync(x => x.Id ==configurationId);
    }

    public async Task<CarConfiguration> AddAsync(CarConfiguration carConfiguration)
    {
         await _context.CarConfigurations.AddAsync(carConfiguration);

         return carConfiguration;
    }

    public async Task<List<CarConfiguration>> GetAllAsync()
    {
        return await _context.CarConfigurations.ToListAsync();
    }
}