using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<List<MatriculaVerificationDto>> VerificarMatriculasAluno(Guid alunoId, List<Guid> cursoIds);
        Task<bool> PossuiMatriculaAtivaEmAlgumCurso(Guid alunoId, List<Guid> cursoIds);
        Task<VerificacaoPedidoMatriculaDto> VerificarMatriculasParaPagamento(Guid alunoId, List<Guid> cursoIds);
    }
}
