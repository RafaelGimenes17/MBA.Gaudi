using MBA.Gaudi.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Commands
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
