using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rrs.Data;

  public class DbDelegator : IDbDelegator
  {
      private readonly IsolationLevel _isolationLevel = IsolationLevel.ReadCommitted;
      private readonly CancellationToken _cancellationToken = CancellationToken.None;

      public IDbConnectionFactory ConnectionFactory { get; }
      
      public DbDelegator(IDbConnectionFactory connectionFactory)
      {
          ConnectionFactory = connectionFactory;
      }

      protected DbDelegator(IDbConnectionFactory connectionFactory, IsolationLevel isolationLevel, CancellationToken cancellationToken) : this(connectionFactory)
      {
          _isolationLevel = isolationLevel;
          _cancellationToken = cancellationToken;
      }

      public IDbDelegator WithCancellationToken(CancellationToken cancellationToken) => new DbDelegator(ConnectionFactory, _isolationLevel, cancellationToken);
      public IDbDelegator WithIsolationLevel(IsolationLevel isolationLevel) => new DbDelegator(ConnectionFactory, isolationLevel, _cancellationToken);

      public IDbDelegator UseDatabase(string databaseName) => new DbDelegator(ConnectionFactory.UseDatabase(databaseName), _isolationLevel, _cancellationToken);
  
      // IDbConnection
      // Sync
      public void Execute(Action<IDbConnection> command)
      {
          using var c = ConnectionFactory.OpenConnection();
          command(c);
      }

      public void Execute<T>(Action<IDbConnection, T> command, T parameter)
      {
          using var c = ConnectionFactory.OpenConnection();
          command.Invoke(c, parameter);
      }

      public T Execute<T>(Func<IDbConnection, T> query)
      {
          using var c = ConnectionFactory.OpenConnection();
          return query.Invoke(c);
      }

      public TOut Execute<TIn, TOut>(Func<IDbConnection, TIn, TOut> query, TIn parameter)
      {
          using var c = ConnectionFactory.OpenConnection();
          return query.Invoke(c, parameter);
      }

      // Async
      public Task Execute(Func<IDbConnection, Task> command) => Execute((c, t) => command(c));

      public async Task Execute(Func<IDbConnection, CancellationToken, Task> command)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          
          await command(c, _cancellationToken);
      }

      public Task Execute<T>(Func<IDbConnection, T, Task> command, T parameter) => Execute((c, p, t) => command(c, p), parameter);

      public async Task Execute<T>(Func<IDbConnection, T, CancellationToken, Task> command, T parameter)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          await command.Invoke(c, parameter, _cancellationToken);
      }

      public Task<T> Execute<T>(Func<IDbConnection, Task<T>> query) => Execute((c, t) => query(c));

      public async Task<T> Execute<T>(Func<IDbConnection, CancellationToken, Task<T>> query)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          return await query.Invoke(c, _cancellationToken);
      }

      public Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, Task<TOut>> query, TIn parameter) => Execute((c, p, t) => query(c, p), parameter);

      public async Task<TOut> Execute<TIn, TOut>(Func<IDbConnection, TIn, CancellationToken, Task<TOut>> query, TIn parameter)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          return await query.Invoke(c, parameter, _cancellationToken);
      }

      // IDbTransaction
      // Sync
      public void Transaction(Action<IDbTransaction> command)
      {
          using var c = ConnectionFactory.OpenConnection();
          using var t = c.BeginTransaction(_isolationLevel);
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

      public void Transaction<T>(Action<IDbTransaction, T> command, T parameter)
      {
          using var c = ConnectionFactory.OpenConnection();
          using var t = c.BeginTransaction(_isolationLevel);
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

      public T Transaction<T>(Func<IDbTransaction, T> query)
      {
          using var c = ConnectionFactory.OpenConnection();
          using var t = c.BeginTransaction(_isolationLevel);
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

      public TOut Transaction<TIn, TOut>(Func<IDbTransaction, TIn, TOut> query, TIn parameter)
      {
          using var c = ConnectionFactory.OpenConnection();
          using var t = c.BeginTransaction(_isolationLevel);

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

      // Async
      public Task Transaction(Func<IDbTransaction, Task> command) => Transaction((c, t) => command(c));

      public async Task Transaction(Func<IDbTransaction, CancellationToken, Task> command)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          using var t = c.BeginTransaction(_isolationLevel);

          try
          {
              await command.Invoke(t, _cancellationToken);
              t.Commit();
          }
          catch
          {
              t.Rollback();
              throw;
          }
      }


      public Task Transaction<T>(Func<IDbTransaction, T, Task> command, T parameter) => Transaction((c, p, t) => command(c, p), parameter);

      public async Task Transaction<T>(Func<IDbTransaction, T, CancellationToken, Task> command, T parameter)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          using var t = c.BeginTransaction(_isolationLevel);
          try
          {
              await command.Invoke(t, parameter, _cancellationToken);
              t.Commit();
          }
          catch
          {
              t.Rollback();
              throw;
          }
      }

      public Task<T> Transaction<T>(Func<IDbTransaction, Task<T>> query) => Transaction((c, t) => query(c));

      public async Task<T> Transaction<T>(Func<IDbTransaction, CancellationToken, Task<T>> query)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          using var t = c.BeginTransaction(_isolationLevel);
          try
          {
              var r = await query.Invoke(t, _cancellationToken);
              t.Commit();
              return r;
          }
          catch
          {
              t.Rollback();
              throw;
          }
      }

      public Task<TOut> Transaction<TIn, TOut>(Func<IDbTransaction, TIn, Task<TOut>> query, TIn parameter) => Transaction((c, p, t) => query(c, p), parameter);

      public async Task<TOut> Transaction<TIn, TOut>(Func<IDbTransaction, TIn, CancellationToken, Task<TOut>> query, TIn parameter)
      {
          using var c = await ConnectionFactory.OpenConnectionAsync(_cancellationToken);
          using var t = c.BeginTransaction(_isolationLevel);
          try
          {
              var r = await query.Invoke(t, parameter, _cancellationToken);
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
