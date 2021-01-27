using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDbNonTransactionalDelegator
    {
        Task Execute(Func<IDbConnection, Task> command);
        Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter);
        Task<T> Execute<T>(Func<IDbConnection, Task<T>> query);
        Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter);
    }
}
