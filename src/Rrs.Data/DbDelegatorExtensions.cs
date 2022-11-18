using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data;

public static class DbDelegatorExtensions
{
    // 2
    public static void Execute<T1, T2>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2> command, T1 parameter1, T2 parameter2)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), (parameter1, parameter2));
    }

    public static TOut Execute<TIn1, TIn2, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TOut> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), (parameter1, parameter2));
    }

    // 3
    public static void Execute<T1, T2, T3>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), (parameter1, parameter2, parameter3));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), (parameter1, parameter2, parameter3));
    }

    // 4
    public static void Execute<T1, T2, T3, T4>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), (parameter1, parameter2, parameter3, parameter4));
    }

    // 5
    public static void Execute<T1, T2, T3, T4, T5>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    // 6
    public static void Execute<T1, T2, T3, T4, T5, T6>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    // 7
    public static void Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbNonTransactionalDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6, T7> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbNonTransactionalDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    // 2
    public static Task Execute<T1, T2>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), (parameter1, parameter2));
    }

    public static Task Execute<T1, T2>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, CancellationToken, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, t), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, t), (parameter1, parameter2));
    }

    // 3
    public static Task Execute<T1, T2, T3>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), (parameter1, parameter2, parameter3));
    }

    public static Task Execute<T1, T2, T3>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, t), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, t), (parameter1, parameter2, parameter3));
    }

    // 4
    public static Task Execute<T1, T2, T3, T4>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task Execute<T1, T2, T3, T4>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    // 5
    public static Task Execute<T1, T2, T3, T4, T5>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task Execute<T1, T2, T3, T4, T5>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    // 6
    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    // 7
    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, T7, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, T7, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbNonTransactionalAsyncDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.Item1, o.Item2, o.Item3, o.Item4, o.Item5, o.Item6, o.Item7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }
}
