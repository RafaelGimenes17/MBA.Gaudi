using FluentValidation;
using MBA.Gaudi.Vendas.Application.Commands;

namespace MBA.Gaudi.Vendas.Application.Validators
{
    public class EfetuarMatriculaCommandValidator : AbstractValidator<EfetuarMatriculaCommand>
    {
        public EfetuarMatriculaCommandValidator()
        {
            RuleFor(c => c.AlunoId)
                .NotEmpty()
                .WithMessage("O código do curso é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O código do curso é inválido.");
        }
    }
}
