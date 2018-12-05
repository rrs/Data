using System;
using System.Data;

namespace Rrs.Data
{
    public interface IDbTransactionalDelegator
    {
        void Execute(Action<IDbConnection, IDbTransaction> command);
        void Execute<T>(Action<IDbConnection, IDbTransaction, T> command, T parameter);
        T Execute<T>(Func<IDbConnection, IDbTransaction, T> query);
        TOut Execute<TIn, TOut>(Func<IDbConnection, IDbTransaction, TIn, TOut> query, TIn parameter);
    }
}
