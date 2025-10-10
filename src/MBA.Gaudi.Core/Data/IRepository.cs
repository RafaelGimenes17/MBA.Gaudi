using MBA.Gaudi.Core.DomainObjects;

namespace MBA.Gaudi.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}