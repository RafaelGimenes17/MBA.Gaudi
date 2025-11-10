using FluentValidation;
using MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Validators
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
