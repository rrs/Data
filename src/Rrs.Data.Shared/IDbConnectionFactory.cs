using System.Data;

namespace Rrs.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenConnection();
    }
}
