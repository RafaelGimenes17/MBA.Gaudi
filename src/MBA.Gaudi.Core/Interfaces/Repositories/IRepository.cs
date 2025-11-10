namespace MBA.Gaudi.Core.Interfaces.Repositories
{    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
