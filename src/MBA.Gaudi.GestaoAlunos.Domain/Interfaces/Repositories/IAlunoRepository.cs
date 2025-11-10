using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoAlunos.Domain.Entites;

namespace MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        void Adicionar(Aluno aluno);
        void Alterar(Aluno aluno);
        void Remover(Aluno aluno);
        Aluno? BuscarPorId(Guid id);
        Aluno? BuscarPorIdNoTracking(Guid id);
        Aluno? BuscarPorUsuarioId(Guid usuarioId);
        Aluno? BuscarPorEmail(string email);
    }
}
