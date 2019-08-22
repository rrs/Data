using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial class DefaultDelegatorBus
    {
        public Task ExecuteAsync(Func<Task> command, MethodInfo originalMethod = null)
        {
            return command();
        }

        public Task ExecuteAsync<T>(Func<T, Task> command, T parameter, MethodInfo originalMethod = null)
        {
            return command(parameter);
        }

        public Task<T> ExecuteAsync<T>(Func<Task<T>> query, MethodInfo originalMethod = null)
        {
            return query();
        }

        public Task<TOut> ExecuteAsync<TIn, TOut>(Func<TIn, Task<TOut>> query, TIn parameter, MethodInfo originalMethod = null)
        {
            return query(parameter);
        }
    }
}
