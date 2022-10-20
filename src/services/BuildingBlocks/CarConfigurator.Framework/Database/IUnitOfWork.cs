namespace CarConfigurator.Framework.Database;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}