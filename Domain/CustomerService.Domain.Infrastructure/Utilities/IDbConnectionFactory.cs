using System.Data;


namespace CustomerService.Domain.Infrastructure.Utilities
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
    }
}
