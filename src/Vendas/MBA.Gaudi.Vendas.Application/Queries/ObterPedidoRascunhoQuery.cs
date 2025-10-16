using MBA.Gaudi.Vendas.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Vendas.Application.Queries
{
    public class ObterPedidoRascunhoQuery : IRequest<Pedido?>
    {
        public Guid AlunoId { get; set; }

        public ObterPedidoRascunhoQuery(Guid alunoId)
        {
            AlunoId = alunoId;
        }
    }
}
