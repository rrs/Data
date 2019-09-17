using System.Data;

namespace Rrs.Data
{
    public partial interface IDbConnectionFactory
    {
        IDbConnection OpenConnection();
        IConnectionProperties ConnectionProperties { get; }
    }
}
