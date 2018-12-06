using System;
using System.Data;

namespace Rrs.Data
{
    public class DbDelegator : IDbDelegator
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IDataBus _dataBus;

        public DbDelegator(IDbConnectionFactory connectionFactory, IDataBus dataBus = null)
        {
            _connectionFactory = connectionFactory;
            _dataBus = dataBus ?? new DefaultDataBus();
        }

        public void Execute(Action<IDbConnection> command)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                _dataBus.Execute(() => command(c), command.Method.Name);
            }
        }

        public void Execute(Action<IDbConnection, IDbTransaction> command)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    _dataBus.Execute(() => command.Invoke(c, t), command.Method.Name);
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
                _dataBus.Execute(p => command.Invoke(c, p), parameter, command.Method.Name);
            }
        }

        public void Execute<T>(Action<IDbConnection, IDbTransaction, T> command, T parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    _dataBus.Execute(p => command.Invoke(c, t, p), parameter, command.Method.Name);
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
                return _dataBus.Execute(() => query.Invoke(c), query.Method.Name);
            }
        }

        public T Execute<T>(Func<IDbConnection, IDbTransaction, T> query)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = _dataBus.Execute(() => query.Invoke(c, t), query.Method.Name);
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
                return _dataBus.Execute(p => query.Invoke(c, p), parameter, query.Method.Name);
            }
        }

        public TOut Execute<TIn, TOut>(Func<IDbConnection,IDbTransaction, TIn, TOut> query, TIn parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = _dataBus.Execute(p => query.Invoke(c, t, p), parameter, query.Method.Name);
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
