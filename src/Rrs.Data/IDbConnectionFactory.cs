using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection NewConnection();
        IDbConnection OpenConnection();
        IConnectionProperties ConnectionProperties { get; }
        Task<IDbConnection> OpenConnectionAsync();
    }
}
