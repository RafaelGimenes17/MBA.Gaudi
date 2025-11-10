using MBA.Gaudi.Pagamentos.Domain.Entities;

namespace MBA.Gaudi.Pagamentos.Domain.Interfaces.Payments
{
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento);
    }
}