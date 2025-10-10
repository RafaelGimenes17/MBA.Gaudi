using MBA.Gaudi.GestaoAlunos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBA.Gaudi.GestaoAlunos.Data.Mappings
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.DataMatricula)
                   .IsRequired();

            builder.Property(a => a.DataValidade)
                   .IsRequired();

            builder.Property(a => a.Ativo)
                   .IsRequired();
        }
    }
}
