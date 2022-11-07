namespace Rrs.Data
{
    public interface IConnectionProperties
    {
        string Server { get; }
        string Database { get; }
        string Username { get; }

        string ConnectionString { get; }
    }
}
