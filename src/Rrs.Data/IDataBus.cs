using System;

namespace Rrs.Data
{
    public interface IDataBus
    {
        void Execute(Action command, string methodName = null);
        void Execute<T>(Action<T> command, T parameter, string methodName = null);
        T Execute<T>(Func<T> query, string methodName = null);
        TOut Execute<TIn, TOut>(Func<TIn, TOut> query, TIn parameter, string methodName = null);
    }
}
