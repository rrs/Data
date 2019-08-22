﻿using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public partial class DbDelegator
    {
        public Task ExecuteAsync(Func<IDbConnection, Task> command)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.ExecuteAsync(() => command(c), command.Method);
            }
        }

        public Task ExecuteAsync(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.ExecuteAsync(() => command.Invoke(t), command.Method);
                    t.Commit();
                    return r;
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public Task ExecuteAsync<T>(Func<IDbConnection, T, Task> command, T parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.ExecuteAsync(p => command.Invoke(c, p), parameter, command.Method);
            }
        }

        public Task ExecuteAsync<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.ExecuteAsync(p => command.Invoke(t, p), parameter, command.Method);
                    t.Commit();
                    return r;
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> query)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.ExecuteAsync(() => query.Invoke(c), query.Method);
            }
        }

        public Task<T> ExecuteAsync<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.ExecuteAsync(() => query.Invoke(t), query.Method);
                    t.Commit();
                    return r;
                }
                finally
                {
                    t.Rollback();
                }
            }
        }

        public Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter)
        {
            using (var c = _connectionFactory.OpenConnection())
            {
                return DelegatorBus.ExecuteAsync(p => query.Invoke(c, p), parameter, query.Method);
            }
        }

        public Task<TOut> ExecuteAsync<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel)
        {
            using (var c = _connectionFactory.OpenConnection())
            using (var t = c.BeginTransaction())
            {
                try
                {
                    var r = DelegatorBus.ExecuteAsync(p => query.Invoke(t, p), parameter, query.Method);
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
