
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Vendas.Application.Validators;
namespace MBA.Gaudi.Vendas.Application.Commands
{
    public class AlterarStatusPedidoPagoCommand : Command
    {
        public Guid PedidoId { get; set; }


        public AlterarStatusPedidoPagoCommand(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarStatusPedidoPagoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
