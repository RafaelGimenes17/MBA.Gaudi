using MBA.Gaudi.Alunos.Application.DTOs;

namespace MBA.Gaudi.Alunos.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<List<MatriculaVerificationDto>> VerificarMatriculasAluno(Guid alunoId, List<Guid> cursoIds);
        Task<bool> PossuiMatriculaAtivaEmAlgumCurso(Guid alunoId, List<Guid> cursoIds);
        Task<VerificacaoPedidoMatriculaDto> VerificarMatriculasParaPagamento(Guid alunoId, List<Guid> cursoIds);
    }
}

