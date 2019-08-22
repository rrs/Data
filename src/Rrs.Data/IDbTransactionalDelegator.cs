using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDbTransactionalDelegator
    {
        Task ExecuteAsync(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task ExecuteAsync<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<T> ExecuteAsync<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
