using FluentValidation;
using MBA.Gaudi.GestaoConteudo.Application.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Validators
{
    public class InativarCursoCommandValidator : AbstractValidator<InativarCursoCommand>
    {
        public InativarCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("Id do curso é obrigatório.");
        }
    }
}
