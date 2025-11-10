using FluentValidation;
using MBA.Gaudi.GestaoConteudo.Application.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Validators
{
    public class AtivarCursoCommandValidator : AbstractValidator<AtivarCursoCommand>
    {
        public AtivarCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .Empty()
                .WithMessage("Id do curso é obrigatório.");
        }
    }
}
