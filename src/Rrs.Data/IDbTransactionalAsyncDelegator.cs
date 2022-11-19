using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbTransactionalAsyncDelegator
    {
        Task Transaction(Func<IDbTransaction, Task> command);
        Task Transaction(Func<IDbTransaction, CancellationToken, Task> command);
        
        Task Transaction<T>(Func<IDbTransaction, T, Task> command, T parameter);
        Task Transaction<T>(Func<IDbTransaction, T, CancellationToken, Task> command, T parameter);
        
        Task<T> Transaction<T>(Func<IDbTransaction, Task<T>> query);
        Task<T> Transaction<T>(Func<IDbTransaction, CancellationToken, Task<T>> query);

        Task<TOut> Transaction<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter);
        Task<TOut> Transaction<TIn, TOut>(Func<IDbTransaction, TIn, CancellationToken, Task<TOut>> query, TIn parameter);
    }
}
