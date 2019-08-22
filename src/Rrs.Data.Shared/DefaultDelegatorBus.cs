using System;
using System.Reflection;

namespace Rrs.Data
{
    public partial class DefaultDelegatorBus : IDelegatorBus
    {
        public void Execute(Action command, MethodInfo originalMethod = null)
        {
            command();
        }

        public void Execute<T>(Action<T> command, T parameter, MethodInfo originalMethod = null)
        {
            command(parameter);
        }

        public T Execute<T>(Func<T> query, MethodInfo originalMethod = null)
        {
            return query();
        }

        public TOut Execute<TIn, TOut>(Func<TIn, TOut> query, TIn parameter, MethodInfo originalMethod = null)
        {
            return query(parameter);
        }
    }
}
