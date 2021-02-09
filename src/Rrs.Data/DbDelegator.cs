using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public class DbDelegator : IDbDelegator
    {
        public IDbConnectionFactory ConnectionFactory { get; }
        public IDelegatorBus DelegatorBus { get; set; }
        public DbDelegator(IDbConnectionFactory connectionFactory, IDelegatorBus delegatorBus = null)
        {
            ConnectionFactory = connectionFactory;
            DelegatorBus = delegatorBus ?? new DefaultDelegatorBus();
        }

        public void Execute(Action<IDbConnection> command)
        {
            using (var c = ConnectionFactory.OpenConnection())
            {
                DelegatorBus.Execute(() => command(c), command.Method);
            }
        }

        public void Execute(Action<IDbTransaction> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    DelegatorBus.Execute(() => command.Invoke(t), command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public void Execute<T>(Action<IDbConnection, T> command, T parameter)
        {
            using (var c = ConnectionFactory.OpenConnection())
            {
                DelegatorBus.Execute(p => command.Invoke(c, p), parameter, command.Method);
            }
        }

        public void Execute<T>(Action<IDbTransaction, T> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    DelegatorBus.Execute(p => command.Invoke(t, p), parameter, command.Method);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public T Execute<T>(Func<IDbConnection, T> query)
        {
            using (var c = ConnectionFactory.OpenConnection())
            {
                return DelegatorBus.Execute(() => query.Invoke(c), query.Method);
            }
        }

        public T Execute<T>(Func<IDbTransaction, T> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.Execute(() => query.Invoke(t), query.Method);
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

        public TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter)
        {
            using (var c = ConnectionFactory.OpenConnection())
            {
                return DelegatorBus.Execute(p => query.Invoke(c, p), parameter, query.Method);
            }
        }

        public TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.Execute(p => query.Invoke(t, p), parameter, query.Method);
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

        public async Task Execute(Func<IDbConnection, Task> command)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync())
            {
                await DelegatorBus.Execute(() => command(c), command.Method);
            }
        }

        public async Task Execute(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
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

        public async Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
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

        public async Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
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

        public async Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
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

        public Task ExecuteInTransaction(Func<IDbTransaction, Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), isolationLevel);

        public Task<T> ExecuteInTransaction<T>(Func<IDbTransaction, Task<T>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), isolationLevel);

        public void ExecuteInTransaction(Action<IDbTransaction> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => action(t), isolationLevel);

        public T ExecuteInTransaction<T>(Func<IDbTransaction, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), isolationLevel);

        public DbDelegatorTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var c = ConnectionFactory.OpenConnection();
            var t = c.BeginTransaction();
            return new DbDelegatorTransaction(c, t, DelegatorBus);
        }

        public async Task<DbDelegatorTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var c = await ConnectionFactory.OpenConnectionAsync();
            var t = c.BeginTransaction();
            return new DbDelegatorTransaction(c, t, DelegatorBus);
        }
    }
}
