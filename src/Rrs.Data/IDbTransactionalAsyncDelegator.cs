using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbTransactionalAsyncDelegator
    {
        Task Execute(Func<IDbTransaction, Task> command);
        Task Execute(Func<IDbTransaction, CancellationToken, Task> command);
        
        Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter);
        Task Execute<T>(Func<IDbTransaction, T, CancellationToken, Task> command, T parameter);
        
        Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query);
        Task<T> Execute<T>(Func<IDbTransaction, CancellationToken, Task<T>> query);

        Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter);
        Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, CancellationToken, Task<TOut>> query, TIn parameter);
    }
}
