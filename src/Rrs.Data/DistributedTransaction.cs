using System;
using System.Collections.Generic;
using System.Data;

namespace Rrs.Data;

internal class DistributedTransaction : IDisposable
{
    private readonly IEnumerable<IDbTransaction> _transactions;

    public DistributedTransaction(IEnumerable<IDbTransaction> transactions) => _transactions = transactions;

    public void Commit()
    {
        List<Exception> exceptions = null;
        foreach(var transaction in _transactions)
        {
            try
            {
                transaction.Commit();
            }
            catch(Exception e)
            {
                if (exceptions == null)
                {
                    exceptions = new List<Exception>();
                }
                exceptions.Add(e);
            }
        }
        if (exceptions != null) throw new AggregateException("Error while committing transactions", exceptions);
    }

    public void Rollback()
    {
        List<Exception> exceptions = null;
        foreach (var transaction in _transactions)
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception e)
            {
                if (exceptions == null)
                {
                    exceptions = new List<Exception>();
                }
                exceptions.Add(e);
            }
        }
        if (exceptions != null) throw new AggregateException(exceptions);
    }

    private bool _disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                List<Exception> exceptions = null;
                foreach (var transaction in _transactions)
                {
                    try
                    {
                        transaction.Dispose();
                    }
                    catch (Exception e)
                    {
                        if (exceptions == null)
                        {
                            exceptions = new List<Exception>();
                        }
                        exceptions.Add(e);
                    }
                }
                if (exceptions != null) throw new AggregateException(exceptions);
            }
            
            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
