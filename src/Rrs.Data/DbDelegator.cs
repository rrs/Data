using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial class DbDelegator
    {
        public async Task Execute(Func<IDbConnection, Task> command)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                await DelegatorBus.Execute(() => command(c), command.Method);
            }
        }

        public async Task Execute(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await DelegatorBus.Execute(() => command.Invoke(t), command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                await DelegatorBus.Execute(p => command.Invoke(c, p), parameter, command.Method);
            }
        }

        public async Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await DelegatorBus.Execute(p => command.Invoke(t, p), parameter, command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<T> Execute<T>(Func<IDbConnection, Task<T>> query)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                return await DelegatorBus.Execute(() => query.Invoke(c), query.Method);
            }
        }

        public async Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await DelegatorBus.Execute(() => query.Invoke(t), query.Method);
                    t.Commit();
                    return r;
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                return await DelegatorBus.Execute(p => query.Invoke(c, p), parameter, query.Method);
            }
        }

        public async Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await DelegatorBus.Execute(p => query.Invoke(t, p), parameter, query.Method);
                    t.Commit();
                    return r;
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public Task ExecuteInTransaction(Func<IDbConnection, Task> func, IsolationLevel isolationLevel) => Execute(t => func(t.Connection), isolationLevel);

        public Task<T> ExecuteInTransaction<T>(Func<IDbConnection, Task<T>> func, IsolationLevel isolationLevel) => Execute(t => func(t.Connection), isolationLevel);
    }
}
