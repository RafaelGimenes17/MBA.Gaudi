using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
{
    public class InativarCursoCommand : Command
    {
        public Guid CursoId { get; set; }

        public InativarCursoCommand(Guid cursoId)
        {
            CursoId = cursoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new InativarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        
    }
}