using System;
using MBA.Gaudi.Core.Models;

namespace MBA.Gaudi.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}