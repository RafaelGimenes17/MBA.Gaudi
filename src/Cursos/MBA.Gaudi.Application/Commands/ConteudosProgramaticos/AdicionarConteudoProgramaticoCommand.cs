using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.ConteudosProgramaticos
{
    public class AdicionarConteudoProgramaticoCommand : Command
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarConteudoProgramaticoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

