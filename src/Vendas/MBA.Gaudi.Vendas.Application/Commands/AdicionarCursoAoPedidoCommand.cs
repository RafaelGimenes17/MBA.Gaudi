using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Vendas.Application.Validators;

namespace MBA.Gaudi.Vendas.Application.Commands
{
    public class AdicionarCursoAoPedidoCommand : Command
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public Guid PedidoId { get; set; }

        public AdicionarCursoAoPedidoCommand(Guid alunoId, Guid cursoId)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarCursoAoPedidoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

