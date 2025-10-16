using MBA.Gaudi.Core.Domain.Interfaces.Repositories;
using MBA.Gaudi.Vendas.Domain.Entities;

namespace MBA.Gaudi.Vendas.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Adicionar(Pedido pedido);
        void Alterar(Pedido pedido);
        void AdicionarItem(PedidoItem item);
        void RemoverItem(PedidoItem item);
        Task<Pedido?> ObterPorId(Guid pedidoId);
        Task<Pedido?> ObterPorIdComTracking(Guid pedidoId);
        Task<Pedido?> ObterPedidoRascunhoPorAlunoId(Guid alunoId);
        Task<List<Pedido>> ObterTodos();
    }
}
