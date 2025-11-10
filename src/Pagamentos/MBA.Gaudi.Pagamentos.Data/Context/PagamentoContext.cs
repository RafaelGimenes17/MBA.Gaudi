using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Repositories;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Pagamentos.Data;
using MBA.Gaudi.Pagamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MBA.Gaudi.Pagamentos.Data.Context
{
    public class PagamentoContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public PagamentoContext(DbContextOptions<PagamentoContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler ?? throw new ArgumentNullException(nameof(mediatorHandler));
        }
        public DbSet<Pagamento> Pagamentos { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetProperties())
                         .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(100)");
            }

            // Ignorar propriedades de domínio que não devem ser persistidas
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagamentoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;
            if (success) await _mediatorHandler.PublicarEventos(this);
            return success;
        }
    }
}
