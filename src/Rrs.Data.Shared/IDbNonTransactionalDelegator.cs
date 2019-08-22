using System;
using System.Data;

namespace Rrs.Data
{
    public partial interface IDbNonTransactionalDelegator
    {
        void Execute(Action<IDbConnection> command);
        void Execute<T>(Action<IDbConnection, T> command, T parameter);
        T Execute<T>(Func<IDbConnection, T> query);
        TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter);
    }
}
