using MBA.Gaudi.GestaoAlunos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .HasMaxLength(Aluno.NomeMaxLength)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(a => a.Email)
                   .HasMaxLength(Aluno.EmailMaxLength)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(a => a.DataCadastro)
                   .IsRequired();

            builder.Property(a => a.Ativo)
                   .IsRequired();

            builder.OwnsOne(a => a.HistoricoAprendizado, hist =>
            {
                hist.Property(h => h.CursoId)
                    .HasColumnName("CursoId");

                hist.Property(h => h.AulaId)
                    .HasColumnName("AulaId");

                hist.Property(h => h.DataAprendizado)
                    .HasColumnName("DataAprendizado");
            });

            builder.HasMany(a => a.Matriculas)
                   .WithOne(m => m.Aluno)
                   .HasForeignKey(m => m.AlunoId);

            builder.HasMany(a => a.Certificados)
                   .WithOne(c => c.Aluno)
                   .HasForeignKey(c => c.AlunoId);
        }
    }
}
