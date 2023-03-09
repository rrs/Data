using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection NewConnection();
        IDbConnection OpenConnection();
        IConnectionProperties ConnectionProperties { get; }
        Task<IDbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default);
        IDbConnectionFactory UseDatabase(string databaseName);
    }
}
