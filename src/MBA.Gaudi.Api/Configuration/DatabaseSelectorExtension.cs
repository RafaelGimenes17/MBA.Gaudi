using MBA.Gaudi.Security.Data;
using Microsoft.EntityFrameworkCore;

namespace MBA.Gaudi.Api.Configuration
{
    public static class DatabaseSelectorExtension
    {
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
