using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public class DbDelegator : IDbDelegator
    {
        public IDbConnectionFactory ConnectionFactory { get; }
        public DbDelegator(IDbConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        public void Execute(Action<IDbConnection> command)
        {
            using (var c = ConnectionFactory.OpenConnection())
            {
                command(c);
            }
        }

        public void Execute(Action<IDbTransaction> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    command.Invoke(t);
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
                command.Invoke(c, parameter);
            }
        }

        public void Execute<T>(Action<IDbTransaction, T> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    command.Invoke(t, parameter);
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
                return query.Invoke(c);
            }
        }

        public T Execute<T>(Func<IDbTransaction, T> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = query.Invoke(t);
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
                return query.Invoke(c, parameter);
            }
        }

        public TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = ConnectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = query.Invoke(t, parameter);
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

        public async Task Execute(Func<IDbConnection, Task> command, CancellationToken cancellationToken = default)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            {
                await command(c);
            }
        }

        public async Task Execute(Func<IDbConnection, CancellationToken, Task> command, CancellationToken cancellationToken = default)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            {
                await command(c, cancellationToken);
            }
        }

        public async Task Execute(Func<IDbTransaction, Task> command, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await command.Invoke(t);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter, CancellationToken cancellationToken = default)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            {
                await command.Invoke(c, parameter);
            }
        }

        public async Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            using (var t = c.BeginTransaction())
            {
                try
                {
                    await command.Invoke(t, parameter);
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<T> Execute<T>(Func<IDbConnection, Task<T>> query, CancellationToken cancellationToken = default)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            {
                return await query.Invoke(c);
            }
        }

        public async Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await query.Invoke(t);
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

        public async Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter, CancellationToken cancellationToken = default)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            {
                return await query.Invoke(c, parameter);
            }
        }

        public async Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (var c = await ConnectionFactory.OpenConnectionAsync(cancellationToken))
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = await query.Invoke(t, parameter);
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

        public Task ExecuteInTransaction(Func<IDbTransaction, Task> func, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), cancellationToken, isolationLevel);

        public Task<T> ExecuteInTransaction<T>(Func<IDbTransaction, Task<T>> func, CancellationToken cancellationToken = default, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), cancellationToken, isolationLevel);

        public void ExecuteInTransaction(Action<IDbTransaction> action, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => action(t), isolationLevel);

        public T ExecuteInTransaction<T>(Func<IDbTransaction, T> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Execute(t => func(t), isolationLevel);
    }
}
