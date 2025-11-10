using FluentValidation;
using MBA.Gaudi.GestaoConteudo.Application.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Validators
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
