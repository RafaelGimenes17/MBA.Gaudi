using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;

namespace MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories
{
    public interface IAulaRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(Aula aula);
        void Alterar(Aula aula);
        void Remover(Aula aula);
        Task<Aula?> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<Aula>> ObterTodasAsync();
        Task<IEnumerable<Aula>> ObterAtivasAsync();
        Task<IEnumerable<Aula>> ObterPorCursoIdAsync(Guid cursoId);
        Task<IEnumerable<Aula>> ObterAtivasPorCursoIdAsync(Guid cursoId);
    }
}
