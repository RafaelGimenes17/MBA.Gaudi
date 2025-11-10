using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
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

