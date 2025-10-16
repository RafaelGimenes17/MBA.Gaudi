using MBA.Gaudi.Alunos.Application.Validators;
using MBA.Gaudi.Core.Domain.Messages;

namespace MBA.Gaudi.Alunos.Application.Commands
{
    public class CriarAlunoCommand : Command
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public CriarAlunoCommand(Guid usuarioId, string nome, string email)
        {
            AggregateId = usuarioId;
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
        }
        public override bool IsValid()
        {
            ValidationResult = new CriarAlunoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

