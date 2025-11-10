using MBA.Gaudi.Core.Domain.DTOs;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MBA.Gaudi.Pagamentos.Domain.Interfaces.Services;
using MediatR;

namespace MBA.Gaudi.Pagamentos.Application.Handlers.Events
{
    public class EfetuarPagamentoEventHandler : INotificationHandler<EfetuarPagamentoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly INotificador _notificador;
        private readonly IPagamentoService _pagamentoService;

        public EfetuarPagamentoEventHandler(
            IMediatorHandler mediatorHandler,
            INotificador notificador,
            IPagamentoService pagamentoService)
        {
            _mediatorHandler = mediatorHandler;
            _notificador = notificador;
            _pagamentoService = pagamentoService;
        }

        public async Task Handle(EfetuarPagamentoEvent message, CancellationToken cancellationToken)
        {
            var pagamentoPedido = new PagamentoPedido
            {
                PedidoId = message.PedidoId,
                AlunoId = message.AlunoId,
                Total = message.Total,
                ListaCursos = message.ListaCursos,
                NomeCartao = message.NomeCartao,
                NumeroCartao = message.NumeroCartao,
                ExpiracaoCartao = message.ExpiracaoCartao,
                CvvCartao = message.CvvCartao
            };

            var transacao = await _pagamentoService.RealizarPagamentoPedido(pagamentoPedido);
        }
    }
}
