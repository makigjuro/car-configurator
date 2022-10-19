using System.Data;

namespace CarConfigurator.Framework.Database;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}