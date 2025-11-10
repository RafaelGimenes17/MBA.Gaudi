using MBA.Gaudi.Alunos.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Alunos.Application.Queries
{
    public class ObterCursosMatriculadosQuery : IRequest<IEnumerable<Matricula>>
    {
        public Guid AlunoId { get; set; }

        public ObterCursosMatriculadosQuery(Guid alunoId)
        {
            AlunoId = alunoId;
        }
    }
}

