using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;
using MBA.Gaudi.Cursos.Domain.Enums;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
{
    public class AtualizarCursoCommand : Command
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public NivelCurso Nivel { get; set; }
        public ConteudoProgramaticoCommand? ConteudoProgramatico { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
