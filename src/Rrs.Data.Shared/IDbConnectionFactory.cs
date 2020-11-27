using System.Data;

namespace Rrs.Data
{
    public partial interface IDbConnectionFactory
    {
        IDbConnection NewConnection();
        IDbConnection OpenConnection();
        IConnectionProperties ConnectionProperties { get; }
    }
}
