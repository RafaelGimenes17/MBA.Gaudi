using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MediatR;

namespace MBA.Gaudi.Vendas.Application.Handlers.Events
{
    public class PagamentoRealizadoEventHandler : INotificationHandler<PagamentoRealizadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PagamentoRealizadoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(PagamentoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new AlterarStatusPedidoPagoCommand(message.PedidoId));
        }
    }
}
