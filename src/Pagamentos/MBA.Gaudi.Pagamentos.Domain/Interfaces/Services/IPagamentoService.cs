using MBA.Gaudi.Core.Domain.DTOs;
using MBA.Gaudi.Pagamentos.Domain.Entities;

namespace MBA.Gaudi.Pagamentos.Domain.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}