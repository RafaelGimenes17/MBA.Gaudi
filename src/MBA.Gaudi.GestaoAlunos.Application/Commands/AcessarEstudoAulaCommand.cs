using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Commands
{
    public class AcessarEstudoAulaCommand : Command
    {
        public Guid AlunoId { get; set; }
        public Guid MatriculaId { get; set; }
        public Guid CursoId { get; set; }
        public Guid AulaId { get; set; }

        public AcessarEstudoAulaCommand(Guid alunoId, Guid matriculaId, Guid cursoId, Guid aulaId)
        {
            AlunoId = alunoId;
            MatriculaId = matriculaId;
            CursoId = cursoId;
            AulaId = aulaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AcessarEstudoAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
