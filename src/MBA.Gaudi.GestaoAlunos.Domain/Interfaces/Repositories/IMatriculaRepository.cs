using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoAlunos.Domain.Entites;

namespace MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Repositories
{
    public interface IMatriculaRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        void Adicionar(Matricula matricula);
        void Alterar(Matricula matricula);
        void Remover(Matricula matricula);

        Matricula? BuscarPorId(Guid id);
        Matricula? BuscarPorAlunoECurso(Guid alunoId, Guid cursoId);
        IEnumerable<Matricula> BuscarPorAluno(Guid alunoId);
        IEnumerable<Matricula> BuscarPorCurso(Guid cursoId);
    }
}
