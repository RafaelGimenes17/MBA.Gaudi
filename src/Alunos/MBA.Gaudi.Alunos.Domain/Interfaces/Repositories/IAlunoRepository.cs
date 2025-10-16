using MBA.Gaudi.Alunos.Domain.Entities;
using MBA.Gaudi.Core.Domain.Interfaces.Repositories;

namespace MBA.Gaudi.Alunos.Domain.Interfaces.Repositories
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

