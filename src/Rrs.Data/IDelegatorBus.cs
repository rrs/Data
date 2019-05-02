using System;
using System.Reflection;

namespace Rrs.Data
{
    public interface IDelegatorBus
    {
        void Execute(Action command, MethodInfo originalMethod = null);
        void Execute<T>(Action<T> command, T parameter, MethodInfo originalMethod = null);
        T Execute<T>(Func<T> query, MethodInfo originalMethod = null);
        TOut Execute<TIn, TOut>(Func<TIn, TOut> query, TIn parameter, MethodInfo originalMethod = null);
    }
}
