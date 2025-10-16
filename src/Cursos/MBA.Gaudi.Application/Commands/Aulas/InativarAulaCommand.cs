using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Aulas
{
    public class InativarAulaCommand : Command
    {
        public Guid Id { get; set; }

        public InativarAulaCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InativarAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

