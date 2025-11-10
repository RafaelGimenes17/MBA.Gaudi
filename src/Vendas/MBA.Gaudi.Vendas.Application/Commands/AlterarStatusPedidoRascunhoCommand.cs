using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Vendas.Application.Validators;

namespace MBA.Gaudi.Vendas.Application.Commands
{
    public class AlterarStatusPedidoRascunhoCommand : Command
    {
        public Guid PedidoId { get; set; }
        

        public AlterarStatusPedidoRascunhoCommand(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarStatusPedidoRascunhoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
