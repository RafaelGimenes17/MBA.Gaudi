using MBA.Gaudi.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Commands
{
    public class IniciarEstudoAulaCommand : Command
    {
        public Guid AlunoId { get; set; }
        public Guid MatriculaId { get; set; }
        public Guid CursoId { get; set; }
        public Guid AulaId { get; set; }

        public IniciarEstudoAulaCommand(Guid alunoId, Guid matriculaId, Guid cursoId, Guid aulaId)
        {
            AlunoId = alunoId;
            MatriculaId = matriculaId;
            CursoId = cursoId;
            AulaId = aulaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new IniciarEstudoAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
