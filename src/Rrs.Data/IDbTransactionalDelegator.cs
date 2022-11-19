using System;
using System.Data;

namespace Rrs.Data
{
    public interface IDbTransactionalDelegator
    {
        void Transaction(Action<IDbTransaction> command);
        void Transaction<T>(Action<IDbTransaction, T> command, T parameter);
        T Transaction<T>(Func<IDbTransaction, T> query);
        TOut Transaction<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter);
    }
}
