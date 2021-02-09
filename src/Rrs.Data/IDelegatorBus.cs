using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public interface IDelegatorBus
    {
        void Execute(Action command, MethodInfo originalMethod = null);
        void Execute<T>(Action<T> command, T parameter, MethodInfo originalMethod = null);
        T Execute<T>(Func<T> query, MethodInfo originalMethod = null);
        TOut Execute<TIn, TOut>(Func<TIn, TOut> query, TIn parameter, MethodInfo originalMethod = null);
        Task Execute(Func<Task> command, MethodInfo originalMethod = null);
        Task Execute<T>(Func<T, Task> command, T parameter, MethodInfo originalMethod = null);
        Task<T> Execute<T>(Func<Task<T>> query, MethodInfo originalMethod = null);
        Task<TOut> Execute<TIn, TOut>(Func<TIn, Task<TOut>> query, TIn parameter, MethodInfo originalMethod = null);
    }
}
