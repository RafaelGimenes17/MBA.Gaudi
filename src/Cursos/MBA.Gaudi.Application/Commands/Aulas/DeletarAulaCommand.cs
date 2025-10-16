using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Aulas
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

