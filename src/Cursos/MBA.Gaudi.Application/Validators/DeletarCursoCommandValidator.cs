using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Cursos;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class DeletarCursoCommandValidator : AbstractValidator<DeletarCursoCommand>
    {
        public DeletarCursoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id do curso é obrigatório.");
        }
    }
}

