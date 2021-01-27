using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDbTransactionalDelegator
    {
        Task Execute(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task ExecuteInTransaction(Func<IDbConnection, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> ExecuteInTransaction<T>(Func<IDbConnection, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
