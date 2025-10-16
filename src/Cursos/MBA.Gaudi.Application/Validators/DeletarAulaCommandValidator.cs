using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Aulas;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class DeletarAulaCommandValidator : AbstractValidator<DeletarAulaCommand>
    {
        public DeletarAulaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID da aula é obrigatório");
        }
    }
}

