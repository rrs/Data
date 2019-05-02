using System;
using System.Data;

namespace Rrs.Data
{
    public static class DbDelegatorExtensions
    {
        public static void Execute<T1, T2>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2> command, T1 parameter1, T2 parameter2)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<T1, T2>(parameter1, parameter2));
        }

        public static TOut Execute<TIn1, TIn2, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TOut> command, TIn1 parameter1, TIn2 parameter2)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<TIn1, TIn2>(parameter1, parameter2));
        }

        public static void Execute<T1, T2>(this IDbTransactionalDelegator dbDelegator, Action<IDbTransaction, T1, T2> command, T1 parameter1, T2 parameter2, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<T1, T2>(parameter1, parameter2), isolationLevel);
        }

        public static TOut Execute<TIn1, TIn2, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TOut> command, TIn1 parameter1, TIn2 parameter2, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), new Tuple<TIn1, TIn2>(parameter1, parameter2));
        }

        public static void Execute<T1, T2, T3>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3> command, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<T1, T2, T3>(parameter1, parameter2, parameter3));
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<TIn1, TIn2, TIn3>(parameter1, parameter2, parameter3));
        }

        public static void Execute<T1, T2, T3>(this IDbTransactionalDelegator dbDelegator, Action<IDbTransaction, T1, T2, T3> command, T1 parameter1, T2 parameter2, T3 parameter3, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<T1, T2, T3>(parameter1, parameter2, parameter3), isolationLevel);
        }

        public static TOut Execute<TIn1, TIn2, TIn3, TOut>(this IDbTransactionalDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), new Tuple<TIn1, TIn2, TIn3>(parameter1, parameter2, parameter3));
        }
    }
}
