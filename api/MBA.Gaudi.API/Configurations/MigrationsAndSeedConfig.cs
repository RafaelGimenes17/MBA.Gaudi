using MBA.Gaudi.Alunos.Data.Context;
using MBA.Gaudi.Core.Data.Context;
using MBA.Gaudi.Cursos.Data.Context;
using MBA.Gaudi.Pagamentos.Data.Context;
using MBA.Gaudi.Vendas.Data.Context;

namespace MBA.Gaudi.API.Configurations
{
    public static class MigrationsAndSeedConfig
    {
        public static void UseMigrationsAndSeedsConfig(this WebApplication app)
        {
            var services = app.Services.CreateScope().ServiceProvider;
            using var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            string environmentName = env.EnvironmentName;
            IdentityMigrationExec.Exec(services).Wait();
            AlunoMigrationExec.Exec(services, environmentName).Wait();
            CursoMigrationExec.Exec(services, environmentName).Wait();
            PedidoMigrationExec.Exec(services).Wait();
            PagamentoMigrationExec.Exec(services).Wait();
        }
    }
}