using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbTransactionalDelegator
    {
        void Execute(Action<IDbTransaction> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Execute<T>(Action<IDbTransaction, T> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        T Execute<T>(Func<IDbTransaction, T> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task Execute(Func<IDbTransaction, Task> command, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
