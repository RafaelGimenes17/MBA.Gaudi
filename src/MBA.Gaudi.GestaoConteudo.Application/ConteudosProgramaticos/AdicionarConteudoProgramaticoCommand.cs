using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.ConteudosProgramaticos
{
    public class AdicionarConteudoProgramaticoCommand : Command
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarConteudoProgramaticoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
