using Microsoft.EntityFrameworkCore;
using MBA.Gaudi.Core.Domain.Interfaces.Repositories;
using MBA.Gaudi.Pagamentos.Domain.Entities;
using MBA.Gaudi.Pagamentos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Pagamentos.Data.Context;

namespace MBA.Gaudi.Pagamentos.Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentoContext _context;

        public PagamentoRepository(PagamentoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public void Adicionar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public async Task<List<Pagamento>> ObterTodos()
        {
            return await _context.Pagamentos
                .Include(p => p.Transacao)
                .AsNoTracking()
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
