using System;

namespace Rrs.Data
{
    public class DefaultDataBus : IDataBus
    {
        public void Execute(Action command, string methodName = null)
        {
            command();
        }

        public void Execute<T>(Action<T> command, T parameter, string methodName = null)
        {
            command(parameter);
        }

        public T Execute<T>(Func<T> query, string methodName = null)
        {
            return query();
        }

        public TOut Execute<TIn, TOut>(Func<TIn, TOut> query, TIn parameter, string methodName = null)
        {
            return query(parameter);
        }
    }
}
