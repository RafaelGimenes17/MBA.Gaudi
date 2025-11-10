using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.Core.Messages;
using MBA.Gaudi.GestaoConteudo.Domain;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Data.Context
{
    public class ConteudoContext : DbContext, IUnitOfWork
    {
        public ConteudoContext(DbContextOptions<ConteudoContext> options)
            : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aula> Aulas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetProperties())
                         .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConteudoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = (await base.SaveChangesAsync()) > 0;
            // if (success) await _mediator.PublicarEventos(this);
            return success;
        }
    }
}
