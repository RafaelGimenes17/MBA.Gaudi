using MBA.Gaudi.Core.Messages;
using MBA.Gaudi.GestaoAlunos.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Commands
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
