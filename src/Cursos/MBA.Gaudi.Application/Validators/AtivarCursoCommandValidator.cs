using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Cursos;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class AtivarCursoCommandValidator : AbstractValidator<AtivarCursoCommand>
    {
        public AtivarCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .Empty()
                .WithMessage("Id do curso é obrigatório.");
        }
    }
}
