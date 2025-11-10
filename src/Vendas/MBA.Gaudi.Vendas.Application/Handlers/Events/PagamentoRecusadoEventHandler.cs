using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MediatR;

namespace MBA.Gaudi.Vendas.Application.Handlers.Events
{
    public class PagamentoRecusadoEventHandler : INotificationHandler<PagamentoRecusadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PagamentoRecusadoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(PagamentoRecusadoEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new AlterarStatusPedidoRascunhoCommand(message.PedidoId));
        }
    }
}
