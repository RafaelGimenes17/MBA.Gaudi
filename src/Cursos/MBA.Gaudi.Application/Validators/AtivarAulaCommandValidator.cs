using FluentValidation;
using MBA.Gaudi.Cursos.Application.Commands.Aulas;

namespace MBA.Gaudi.Cursos.Application.Validators
{
    public class AtivarAulaCommandValidator : AbstractValidator<AtivarAulaCommand>
    {
        public AtivarAulaCommandValidator()
        {
            RuleFor(x => x.AulaId)
                .NotEmpty()
                .WithMessage("O ID da aula é obrigatório");
        }
    }
}

