using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Queries
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
