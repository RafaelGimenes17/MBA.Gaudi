using MBA.Gaudi.Core.Application.Validators.Identity;
using MBA.Gaudi.Core.Domain.Messages;

namespace MBA.Gaudi.Core.Application.Commands.Identity
{
    public class CriarUsuarioIdentityCommand : Command
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public CriarUsuarioIdentityCommand(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }
        public void SetUsuarioId(Guid usuarioId)
        {
            AggregateId = usuarioId;
        }
        public override bool IsValid()
        {
            ValidationResult = new CriarUsuarioIdentityCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

