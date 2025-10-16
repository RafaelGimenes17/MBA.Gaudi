using MBA.Gaudi.Core.Domain.Interfaces.Repositories;
using MBA.Gaudi.Pagamentos.Domain.Entities;

namespace MBA.Gaudi.Pagamentos.Domain.Interfaces.Repositories
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);
        void AdicionarTransacao(Transacao transacao);
        Task<List<Pagamento>> ObterTodos();
    }
}