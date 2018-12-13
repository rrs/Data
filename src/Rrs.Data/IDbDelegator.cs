namespace Rrs.Data
{
    public interface IDbDelegator : IDbNonTransactionalDelegator, IDbTransactionalDelegator
    {
        IDataBus DataBus { get; set; }
    }
}
