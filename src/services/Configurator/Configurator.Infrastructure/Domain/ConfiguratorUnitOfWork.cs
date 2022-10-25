using CarConfigurator.Framework.Database;

namespace Configurator.Infrastructure.Domain;

public class ConfiguratorUnitOfWork : IUnitOfWork
{
    private readonly ConfiguratorContext _context;

    public ConfiguratorUnitOfWork(ConfiguratorContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await this._context.SaveChangesAsync(cancellationToken);
    }
}
