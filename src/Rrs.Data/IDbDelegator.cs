using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbDelegator : IDbNonTransactionalDelegator, IDbTransactionalDelegator
    {
        IDelegatorBus DelegatorBus { get; set; }
        IDbConnectionFactory ConnectionFactory { get; }
        void ExecuteInTransaction(Action<IDbTransaction> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        T ExecuteInTransaction<T>(Func<IDbTransaction, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task ExecuteInTransaction(Func<IDbTransaction, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> ExecuteInTransaction<T>(Func<IDbTransaction, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        DbDelegatorTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<DbDelegatorTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

    }
}
