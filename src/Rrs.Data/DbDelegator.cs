using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial class DbDelegator
    {
        public async Task ExecuteAsync(Func<IDbConnection, Task> command)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                await DelegatorBus.ExecuteAsync(() => command(c), command.Method);
            }
        }

        public async Task ExecuteAsync(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await DelegatorBus.ExecuteAsync(() => command.Invoke(t), command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task ExecuteAsync<T>(Func<IDbConnection, T, Task> command, T parameter)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                await DelegatorBus.ExecuteAsync(p => command.Invoke(c, p), parameter, command.Method);
            }
        }

        public async Task ExecuteAsync<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await DelegatorBus.ExecuteAsync(p => command.Invoke(t, p), parameter, command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> query)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                return await DelegatorBus.ExecuteAsync(() => query.Invoke(c), query.Method);
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await DelegatorBus.ExecuteAsync(() => query.Invoke(t), query.Method);
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

        public async Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                return await DelegatorBus.ExecuteAsync(p => query.Invoke(c, p), parameter, query.Method);
            }
        }

        public async Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await DelegatorBus.ExecuteAsync(p => query.Invoke(t, p), parameter, query.Method);
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
    }
}
