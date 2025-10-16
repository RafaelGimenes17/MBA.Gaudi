using MBA.Gaudi.Pagamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBA.Gaudi.Pagamentos.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.PedidoId)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Valor)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(p => p.NomeCartao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.NumeroCartao)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.Property(p => p.ExpiracaoCartao)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(p => p.CvvCartao)
                .IsRequired()
                .HasColumnType("varchar(3)");

            // Relacionamento 1:1 com Transacao
            builder.HasOne(p => p.Transacao)
                .WithOne(t => t.Pagamento)
                .HasForeignKey<Transacao>(t => t.PagamentoId);
        }
    }
}

