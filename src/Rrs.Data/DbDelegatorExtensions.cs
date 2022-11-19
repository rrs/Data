using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data;

public static class DbDelegatorExtensions
{
    // 2
    public static void Execute<T1, T2>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2> command, T1 parameter1, T2 parameter2)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    public static TOut Execute<TIn1, TIn2, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TOut> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    // 3
    public static void Execute<T1, T2, T3>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2, T3> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    // 4
    public static void Execute<T1, T2, T3, T4>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    // 5
    public static void Execute<T1, T2, T3, T4, T5>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    // 6
    public static void Execute<T1, T2, T3, T4, T5, T6>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    // 7
    public static void Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbDelegator dbDelegator, Action<IDbConnection, T1, T2, T3, T4, T5, T6, T7> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static TOut Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    // 2
    // IDbConnection
    public static Task Execute<T1, T2>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    public static Task Execute<T1, T2>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, CancellationToken, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, t), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, t), (parameter1, parameter2));
    }

    // IDbTransaction
    public static Task Execute<T1, T2>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    public static Task Execute<T1, T2>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, CancellationToken, Task> command, T1 parameter1, T2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, t), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2), (parameter1, parameter2));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, t), (parameter1, parameter2));
    }

    // 3
    // IDbConnection
    public static Task Execute<T1, T2, T3>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    public static Task Execute<T1, T2, T3>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, t), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, t), (parameter1, parameter2, parameter3));
    }

    // IDbTransaction
    public static Task Execute<T1, T2, T3>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    public static Task Execute<T1, T2, T3>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, t), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3), (parameter1, parameter2, parameter3));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, t), (parameter1, parameter2, parameter3));
    }

    // 4
    // IDbConnection
    public static Task Execute<T1, T2, T3, T4>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task Execute<T1, T2, T3, T4>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    // IDbTransaction
    public static Task Execute<T1, T2, T3, T4>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task Execute<T1, T2, T3, T4>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4), (parameter1, parameter2, parameter3, parameter4));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, t), (parameter1, parameter2, parameter3, parameter4));
    }

    // 5
    // IDbConnection
    public static Task Execute<T1, T2, T3, T4, T5>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task Execute<T1, T2, T3, T4, T5>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    // IDbTransaction
    public static Task Execute<T1, T2, T3, T4, T5>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task Execute<T1, T2, T3, T4, T5>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, t), (parameter1, parameter2, parameter3, parameter4, parameter5));
    }

    // 6
    // IDbConnection
    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    // IDbTransaction
    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6));
    }

    // 7
    // IDbConnection
    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, T7, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbDelegator dbDelegator, Func<IDbConnection, T1, T2, T3, T4, T5, T6, T7, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbDelegator dbDelegator, Func<IDbConnection, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    // IDbTransaction
    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, T7, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task Execute<T1, T2, T3, T4, T5, T6, T7>(this IDbDelegator dbDelegator, Func<IDbTransaction, T1, T2, T3, T4, T5, T6, T7, CancellationToken, Task> command, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, T5 parameter5, T6 parameter6, T7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }

    public static Task<TOut> Execute<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this IDbDelegator dbDelegator, Func<IDbTransaction, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, CancellationToken, Task<TOut>> command, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4, TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
    {
        return dbDelegator.Execute((c, o, t) => command(c, o.parameter1, o.parameter2, o.parameter3, o.parameter4, o.parameter5, o.parameter6, o.parameter7, t), (parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7));
    }
}
