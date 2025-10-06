using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}