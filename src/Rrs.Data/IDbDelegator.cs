using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbDelegator : IDbNonTransactionalDelegator, IDbTransactionalDelegator
    {
        IDbConnectionFactory ConnectionFactory { get; }
        void ExecuteInTransaction(Action<IDbTransaction> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        T ExecuteInTransaction<T>(Func<IDbTransaction, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task ExecuteInTransaction(Func<IDbTransaction, Task> func, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> ExecuteInTransaction<T>(Func<IDbTransaction, Task<T>> func, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
