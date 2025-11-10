using MBA.Gaudi.Core.Domain.Interfaces.Repositories;
using MBA.Gaudi.Cursos.Domain.Entities;

namespace MBA.Gaudi.Cursos.Domain.Interfaces.Repositories
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

