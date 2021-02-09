using System;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Data
{
    public class DbDelegatorTransaction : IDbTransactionalDelegator, IDisposable
    {
        private readonly IDbConnection _c;
        private readonly IDbTransaction _t;
        private readonly IDelegatorBus _delegatorBus;

        public DbDelegatorTransaction(IDbConnection c, IDbTransaction t, IDelegatorBus delegatorBus)
        {
            _c = c;
            _t = t;
            _delegatorBus = delegatorBus;
        }

        public void Dispose()
        {
            _c.Dispose();
            _t.Dispose();
        }

        public void Rollback() => _t.Rollback();
        public void Commit() => _t.Commit();

        public void Execute(Action<IDbTransaction> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(() => command.Invoke(_t), command.Method);

        public void Execute<T>(Action<IDbTransaction, T> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(p => command.Invoke(_t, p), parameter, command.Method);

        public T Execute<T>(Func<IDbTransaction, T> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(() => query.Invoke(_t), query.Method);

        public TOut Execute<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(p => query.Invoke(_t, p), parameter, query.Method);

        public Task Execute(Func<IDbTransaction, Task> command, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(() => command.Invoke(_t), command.Method);

        public Task Execute<T>(Func<IDbTransaction, T, Task> command, T parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(p => command.Invoke(_t, p), parameter, command.Method);

        public Task<T> Execute<T>(Func<IDbTransaction, Task<T>> query, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(() => query.Invoke(_t), query.Method);

        public Task<TOut> Execute<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _delegatorBus.Execute(p => query.Invoke(_t, p), parameter, query.Method);
    }
}
