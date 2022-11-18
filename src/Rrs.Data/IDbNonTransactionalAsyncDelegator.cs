using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbNonTransactionalAsyncDelegator
    {
        Task Execute(Func<IDbConnection, Task> command);
        Task Execute(Func<IDbConnection, CancellationToken, Task> command);

        Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter);
        Task Execute<T>(Func<IDbConnection, T, CancellationToken, Task> command, T parameter);
        
        Task<T> Execute<T>(Func<IDbConnection, Task<T>> query);
        Task<T> Execute<T>(Func<IDbConnection, CancellationToken, Task<T>> query);
        
        Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter);
        Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, CancellationToken, Task<TOut>> query, TIn parameter);
    }
}
