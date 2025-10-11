using MBA.Gaudi.Security.Data;
using Microsoft.EntityFrameworkCore;

namespace MBA.Gaudi.Api.Configuration
{
    public static class DatabaseSelectorExtension
    {
        /// <summary>
        /// Adiciona o provedor de banco de dados apropriado à coleção de serviços dependendo do ambiente.
        /// Utiliza SQLite em desenvolvimento e SQL Server nos demais casos.
        /// </summary>
        /// <param name="builder">O <see cref="WebApplicationBuilder"/> a ser configurado.</param>
        public static WebApplicationBuilder AddDatabaseSelector(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<SecurityDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite")));
            }
            else
            {
                builder.Services.AddDbContext<SecurityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            }

            return builder;
        }
    }
}
