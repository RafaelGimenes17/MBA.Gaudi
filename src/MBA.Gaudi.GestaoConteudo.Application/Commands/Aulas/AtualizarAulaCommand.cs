using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas
{
    public class AtualizarAulaCommand : Command
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public int DuracaoMinutos { get; set; }
        public int Ordem { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
