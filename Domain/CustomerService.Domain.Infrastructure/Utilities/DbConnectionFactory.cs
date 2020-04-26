using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerService.Domain.Infrastructure.Utilities
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;

        public DbConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }

        public IDbConnection CreateDbConnection(DatabaseConnectionName connectionName)
        {
            if (_connectionDict.TryGetValue(connectionName, out string connectionString))
            {
                return new SqlConnection(connectionString);
            }

            throw new ArgumentNullException("DatabaseConnectionName key is not present in the dictionary");
        }
    }
}
