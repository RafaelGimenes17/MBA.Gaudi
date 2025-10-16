using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Aulas
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

