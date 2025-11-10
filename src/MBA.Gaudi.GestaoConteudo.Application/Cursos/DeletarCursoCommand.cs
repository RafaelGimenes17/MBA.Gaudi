using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class DeletarCursoCommand : Command
    {
        public Guid Id { get; set; }

        public DeletarCursoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeletarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
