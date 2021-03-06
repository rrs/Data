﻿namespace Rrs.Data
{
    public interface IConnectionProperties
    {
        string Server { get; }
        string Database { get; }
        string Username { get; }
        string Password { get; }

        string ConnectionString { get; }
    }
}
