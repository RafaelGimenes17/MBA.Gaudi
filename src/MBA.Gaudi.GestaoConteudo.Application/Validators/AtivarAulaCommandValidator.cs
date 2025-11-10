using FluentValidation;
using MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Validators
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
