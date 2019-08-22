using System;
using System.Data;

namespace Rrs.Data
{
    public partial class DbDelegator : IDbDelegator
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public IDelegatorBus DelegatorBus { get; set; }

        public DbDelegator(IDbConnectionFactory connectionFactory, IDelegatorBus delegatorBus = null)
        {
            _connectionFactory = connectionFactory;
            DelegatorBus = delegatorBus ?? new DefaultDelegatorBus();
        }

        public void Execute(Action<IDbConnection> command)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                DelegatorBus.Execute(() => command(c), command.Method);
            }
        }

        public void Execute(Action<IDbTransaction> command, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    DelegatorBus.Execute(() => command.Invoke(t), command.Method);
                    t.Commit();
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public void Execute<T>(Action<IDbConnection, T> command, T parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                DelegatorBus.Execute(p => command.Invoke(c, p), parameter, command.Method);
            }
        }

        public void Execute<T>(Action<IDbTransaction, T> command, T parameter, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    DelegatorBus.Execute(p => command.Invoke(t, p), parameter, command.Method);
                    t.Commit();
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public T Execute<T>(Func<IDbConnection, T> query)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.Execute(() => query.Invoke(c), query.Method);
            }
        }

        public T Execute<T>(Func<IDbTransaction, T> query, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.Execute(() => query.Invoke(t), query.Method);
                    t.Commit();
                    return r;
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.Execute(p => query.Invoke(c, p), parameter, query.Method);
            }
        }

        public TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.Execute(p => query.Invoke(t, p), parameter, query.Method);
                    t.Commit();
                    return r;
                }
                finally
                {
                    t.Rollback();
                }
            }
        }
    }
}
