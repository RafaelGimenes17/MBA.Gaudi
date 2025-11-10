using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
{
    public class AtivarCursoCommand : Command
    {
        public Guid CursoId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtivarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}


