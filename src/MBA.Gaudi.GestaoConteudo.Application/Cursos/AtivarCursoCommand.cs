using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class AtivarCursoCommand : Command
    {
        public Guid CursoId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtivarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
