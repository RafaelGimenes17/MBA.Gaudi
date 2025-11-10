using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas
{
    public class AtivarAulaCommand : Command
    {
        public Guid AulaId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtivarAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
