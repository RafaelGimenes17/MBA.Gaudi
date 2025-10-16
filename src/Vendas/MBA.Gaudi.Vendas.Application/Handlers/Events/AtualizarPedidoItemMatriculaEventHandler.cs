using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MediatR;

namespace MBA.Gaudi.Vendas.Application.Handlers.Events
{
    public class AtualizarPedidoItemMatriculaEventHandler : INotificationHandler<AtualizarPedidoItemMatriculaEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public AtualizarPedidoItemMatriculaEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(AtualizarPedidoItemMatriculaEvent message, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new AtualizarPedidoItemMatriculaCommand(message.PedidoId,message.Matriculas));
        }
    }
}
