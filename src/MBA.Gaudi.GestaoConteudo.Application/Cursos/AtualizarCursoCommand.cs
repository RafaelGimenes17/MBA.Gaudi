using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class AtualizarCursoCommand : Command
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public NivelCurso Nivel { get; set; }
        public ConteudoProgramaticoCommand? ConteudoProgramatico { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
