﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MBA.Gaudi.Security
{
    public class AppDbContext : IdentityDbContext
    {
        public bool UsingSqlLite { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)

        {
            UsingSqlLite = !string.IsNullOrWhiteSpace(configuration.GetConnectionString("DefaultConnectionLite"));

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            ChangeTracker.AutoDetectChangesEnabled = false;

        }

        //public DbSet<Produto> Produtos { get; set; }

        //public DbSet<Categoria> Categorias { get; set; }

        //public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()

                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))

                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))

                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)

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

            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
