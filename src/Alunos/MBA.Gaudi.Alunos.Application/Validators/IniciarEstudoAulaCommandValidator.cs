using FluentValidation;
using MBA.Gaudi.Alunos.Application.Commands;

namespace MBA.Gaudi.Alunos.Application.Validators
{
    public class IniciarEstudoAulaCommandValidator : AbstractValidator<IniciarEstudoAulaCommand>
    {
        public IniciarEstudoAulaCommandValidator()
        {
            RuleFor(c => c.AlunoId)
                .NotEmpty()
                .WithMessage("O ID do aluno é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do aluno é inválido.");

            RuleFor(c => c.MatriculaId)
                .NotEmpty()
                .WithMessage("O ID da matrícula é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O ID da matrícula é inválido.");

            RuleFor(c => c.CursoId)
                .NotEmpty()
                .WithMessage("O ID do curso é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do curso é inválido.");

            RuleFor(c => c.AulaId)
                .NotEmpty()
                .WithMessage("O ID da aula é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O ID da aula é inválido.");
        }
    }
}

