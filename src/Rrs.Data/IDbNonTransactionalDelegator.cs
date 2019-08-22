using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDbNonTransactionalDelegator
    {
        Task ExecuteAsync(Func<IDbConnection, Task> command);
        Task ExecuteAsync<T>(Func<IDbConnection, T, Task> command, T parameter);
        Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> query);
        Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter);
    }
}
