using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public static partial class DbDelegatorExtensions
    {
        // 2
        public static Task ExecuteAsync<T1, T2>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, Task> command, T1 parameter1, T2 parameter2)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2), new Tuple<T1, T2>(parameter1, parameter2));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2), new Tuple<TIn1, TIn2>(parameter1, parameter2));
        }

        public static Task ExecuteAsync<T1, T2>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, Task> command, T1 parameter1, T2 parameter2, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2), new Tuple<T1, T2>(parameter1, parameter2), isolationLevel);
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2), new Tuple<TIn1, TIn2>(parameter1, parameter2), isolationLevel);
        }

        // 3
        public static Task ExecuteAsync<T1, T2, T3>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<T1, T2, T3>(parameter1, parameter2, parameter3));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<TIn1, TIn2, TIn3>(parameter1, parameter2, parameter3));
        }

        public static Task ExecuteAsync<T1, T2, T3>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<T1, T2, T3>(parameter1, parameter2, parameter3), isolationLevel);
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<TIn1, TIn2, TIn3>(parameter1, parameter2, parameter3), isolationLevel);
        }

        // 4
        public static Task ExecuteAsync<T1, T2, T3, T4>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<T1, T2, T3, T4>(parameter1, parameter2, parameter3, parameter4));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<TIn1, TIn2, TIn3, TIn4>(parameter1, parameter2, parameter3, parameter4));
        }

        public static Task Execute<T1, T2, T3, T4>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<T1, T2, T3, T4>(parameter1, parameter2, parameter3, parameter4), isolationLevel);
        }

        public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), new Tuple<TIn1, TIn2, TIn3, TIn4>(parameter1, parameter2, parameter3, parameter4), isolationLevel);
        }
    }
}
