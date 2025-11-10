using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;

namespace MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories
{
    public interface ICursoRepository : IRepository<Curso>
    {
        void Adicionar(Curso curso);
        void Alterar(Curso curso);
        void Remover(Curso curso);
        Task<Curso> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<Curso>> ObterTodosAsync();
        Task<IEnumerable<Curso>> ObterAtivosAsync();
    }
}
