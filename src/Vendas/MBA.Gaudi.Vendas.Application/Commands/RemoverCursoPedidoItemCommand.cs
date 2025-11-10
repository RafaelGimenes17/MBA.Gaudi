using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Vendas.Application.Validators;

namespace MBA.Gaudi.Vendas.Application.Commands
{
    public class RemoverCursoDoPedidoCommand : Command
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }

        public RemoverCursoDoPedidoCommand(Guid alunoId, Guid cursoId)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverCursoDoPedidoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
