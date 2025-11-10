using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class InativarCursoCommand : Command
    {
        public Guid CursoId { get; set; }

        public InativarCursoCommand(Guid cursoId)
        {
            CursoId = cursoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new InativarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
