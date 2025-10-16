using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Application.Validators;

namespace MBA.Gaudi.Cursos.Application.Commands.Aulas
{
    public class AtualizarAulaCommand : Command
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public int DuracaoMinutos { get; set; }
        public int Ordem { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarAulaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

