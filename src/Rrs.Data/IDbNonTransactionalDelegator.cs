using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbNonTransactionalDelegator
    {
        void Execute(Action<IDbConnection> command);
        void Execute<T>(Action<IDbConnection, T> command, T parameter);
        T Execute<T>(Func<IDbConnection, T> query);
        TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter);
        Task Execute(Func<IDbConnection, Task> command, CancellationToken cancellationToken = default);
        //Task Execute(Func<IDbConnection, CancellationToken, Task> command, CancellationToken cancellationToken = default);
        Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter, CancellationToken cancellationToken = default);
        //Task Execute<T>(Func<IDbConnection, T, CancellationToken, Task> command, T parameter, CancellationToken cancellationToken = default);
        Task<T> Execute<T>(Func<IDbConnection, Task<T>> query, CancellationToken cancellationToken = default);
        //Task<T> Execute<T>(Func<IDbConnection, CancellationToken, Task<T>> query, CancellationToken cancellationToken = default);
        Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter, CancellationToken cancellationToken = default);
        //Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, CancellationToken, Task<TOut>> query, TIn parameter, CancellationToken cancellationToken = default);
    }
}
