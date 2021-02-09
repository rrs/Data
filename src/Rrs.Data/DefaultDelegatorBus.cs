using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public class DefaultDelegatorBus : IDelegatorBus
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
        public Task Execute(Func<Task> command, MethodInfo originalMethod = null)
        {
            return command();
        }

        public Task Execute<T>(Func<T, Task> command, T parameter, MethodInfo originalMethod = null)
        {
            return command(parameter);
        }

        public Task<T> Execute<T>(Func<Task<T>> query, MethodInfo originalMethod = null)
        {
            return query();
        }

        public Task<TOut> Execute<TIn, TOut>(Func<TIn, Task<TOut>> query, TIn parameter, MethodInfo originalMethod = null)
        {
            return query(parameter);
        }
    }
}
