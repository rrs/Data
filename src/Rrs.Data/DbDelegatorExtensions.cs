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

        // 5
        public static Task ExecuteAsync<T1, T2, T3, T4, T5>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<T1, T2, T3, T4, T5>(parameter1, parameter2, parameter3, parameter4, parameter5));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5>(parameter1, parameter2, parameter3, parameter4, parameter5));
        }

        public static Task Execute<T1, T2, T3, T4, T5>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<T1, T2, T3, T4, T5>(parameter1, parameter2, parameter3, parameter4, parameter5), isolationLevel);
        }

        public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5>(parameter1, parameter2, parameter3, parameter4, parameter5), isolationLevel);
        }

        // 6
        public static Task ExecuteAsync<T1, T2, T3, T4, T5, T6>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<T1, T2, T3, T4, T5, T6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
        }

        public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<T1, T2, T3, T4, T5, T6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6), isolationLevel);
        }

        public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6), isolationLevel);
        }

        // 7
        public static Task ExecuteAsync<T1, T2, T3, T4, T5, T6, T7>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, T7, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<T1, T2, T3, T4, T5, T6, T7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
        }

        public static Task<TOut> ExecuteAsync<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
        {
            return dbDelegator.ExecuteAsync((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
        }

        public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, T7, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<T1, T2, T3, T4, T5, T6, T7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7), isolationLevel);
        }

        public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), new Tuple<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7), isolationLevel);
        }
    }
}
