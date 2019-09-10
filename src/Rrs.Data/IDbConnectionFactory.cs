using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDbConnectionFactory
    {
        Task<IDbConnection> OpenConnectionAsync();
    }
}
