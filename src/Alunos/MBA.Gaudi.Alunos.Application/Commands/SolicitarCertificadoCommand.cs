using MBA.Gaudi.Alunos.Application.Validators;
using MBA.Gaudi.Core.Domain.Messages;

namespace MBA.Gaudi.Alunos.Application.Commands
{
    public class SolicitarCertificadoCommand : Command
    {
        public Guid AlunoId { get; set; }
        public Guid MatriculaId { get; set; }
        public Guid CursoId { get; set; }

        public SolicitarCertificadoCommand(Guid alunoId, Guid matriculaId, Guid cursoId)
        {
            AlunoId = alunoId;
            MatriculaId = matriculaId;
            CursoId = cursoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new SolicitarCertificadoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

