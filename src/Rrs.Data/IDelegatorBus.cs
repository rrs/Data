using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial interface IDelegatorBus
    {
        Task Execute(Func<Task> command, MethodInfo originalMethod = null);
        Task Execute<T>(Func<T, Task> command, T parameter, MethodInfo originalMethod = null);
        Task<T> Execute<T>(Func<Task<T>> query, MethodInfo originalMethod = null);
        Task<TOut> Execute<TIn, TOut>(Func<TIn, Task<TOut>> query, TIn parameter, MethodInfo originalMethod = null);
    }
}
