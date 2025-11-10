namespace MBA.Gaudi.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
