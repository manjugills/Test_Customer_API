using System;
using System.Data;

namespace CustomerService.Domain.Infrastructure.Utilities
{
    public class Repository: IDisposable
    {
        public IDbConnection DbConnection { get; private set; }

        public Repository(IDbConnectionFactory dbConnectionFactory)
        {
            DbConnection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.CustomerDb);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbConnection?.Dispose();
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
