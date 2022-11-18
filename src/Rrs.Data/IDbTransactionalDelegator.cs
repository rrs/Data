using System;
using System.Data;

namespace Rrs.Data
{
    public interface IDbTransactionalDelegator
    {
        void Execute(Action<IDbTransaction> command);
        void Execute<T>(Action<IDbTransaction, T> command, T parameter);
        T Execute<T>(Func<IDbTransaction, T> query);
        TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter);
    }
}
