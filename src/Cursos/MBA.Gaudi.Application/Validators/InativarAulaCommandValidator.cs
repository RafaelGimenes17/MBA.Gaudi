using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Aulas;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class InativarAulaCommandValidator : AbstractValidator<InativarAulaCommand>
    {
        public InativarAulaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID da aula é obrigatório");
        }
    }
}

