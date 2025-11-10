using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas
{
    public class DeletarAulaCommand : Command
    {
        public Guid Id { get; set; }

        public DeletarAulaCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeletarAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
