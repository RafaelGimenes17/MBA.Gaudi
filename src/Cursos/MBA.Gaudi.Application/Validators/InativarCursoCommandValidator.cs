using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Cursos;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class InativarCursoCommandValidator : AbstractValidator<InativarCursoCommand>
    {
        public InativarCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("Id do curso é obrigatório.");
        }
    }
}
