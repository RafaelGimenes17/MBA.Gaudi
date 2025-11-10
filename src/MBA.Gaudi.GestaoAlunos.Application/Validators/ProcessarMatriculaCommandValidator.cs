using FluentValidation;
using MBA.Gaudi.GestaoAlunos.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Validators
{
    public class ProcessarMatriculaCommandValidator : AbstractValidator<ProcessarMatriculaCommand>
    {
        public ProcessarMatriculaCommandValidator()
        {
            RuleFor(c => c.AlunoId)
                .NotEmpty().WithMessage("O ID do aluno é obrigatório")
                .NotEqual(Guid.Empty).WithMessage("O ID do aluno deve ser válido");

            RuleFor(c => c.PedidoId)
                .NotEmpty().WithMessage("O ID do pedido é obrigatório")
                .NotEqual(Guid.Empty).WithMessage("O ID do pedido deve ser válido");

            RuleFor(c => c.ListaCursos)
                .NotNull().WithMessage("A lista de cursos é obrigatória");

            RuleFor(c => c.ListaCursos.Itens)
                .NotEmpty().WithMessage("A lista de cursos não pode estar vazia")
                .When(c => c.ListaCursos != null);
        }
    }
}
