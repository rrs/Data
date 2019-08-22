using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDelegatorBus
    {
        Task ExecuteAsync(Func<Task> command, MethodInfo originalMethod = null);
        Task ExecuteAsync<T>(Func<T, Task> command, T parameter, MethodInfo originalMethod = null);
        Task<T> ExecuteAsync<T>(Func<Task<T>> query, MethodInfo originalMethod = null);
        Task<TOut> ExecuteAsync<TIn, TOut>(Func<TIn, Task<TOut>> query, TIn parameter, MethodInfo originalMethod = null);
    }
}
