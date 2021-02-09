using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDbNonTransactionalDelegator
    {
        void Execute(Action<IDbConnection> command);
        void Execute<T>(Action<IDbConnection, T> command, T parameter);
        T Execute<T>(Func<IDbConnection, T> query);
        TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter);
        Task Execute(Func<IDbConnection, Task> command);
        Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter);
        Task<T> Execute<T>(Func<IDbConnection, Task<T>> query);
        Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter);
    }
}
