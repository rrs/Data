namespace Rrs.Data
{
    public interface IDbDelegator : IDbNonTransactionalDelegator, IDbTransactionalDelegator
    {
        IDelegatorBus DelegatorBus { get; set; }
    }
}
