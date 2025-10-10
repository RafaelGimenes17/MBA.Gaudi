using MBA.Gaudi.Core.Data;
using MBA.Gaudi.Core.Messages;
using MBA.Gaudi.GestaoConteudo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Data
{
    public class ConteudoContext : DbContext, IUnitOfWork
    {
        public ConteudoContext(DbContextOptions<ConteudoContext> options)
            : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aula> Aulas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConteudoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
