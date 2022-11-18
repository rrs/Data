using System.Data;
using System.Threading;

namespace Rrs.Data
{
    public interface IDbDelegator : IDbNonTransactionalDelegator, IDbTransactionalDelegator, IDbNonTransactionalAsyncDelegator, IDbTransactionalAsyncDelegator
    {
        IDbConnectionFactory ConnectionFactory { get; }
        IDbDelegator WithCancellationToken(CancellationToken cancellationToken);
        IDbDelegator WithIsolationLevel(IsolationLevel isolationLevel);
    }
}
