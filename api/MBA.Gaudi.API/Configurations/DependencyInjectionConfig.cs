using MBA.Gaudi.Alunos.Data.Repositories;
using MBA.Gaudi.Alunos.Data.Services;
using MBA.Gaudi.Alunos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Alunos.Domain.Interfaces.Services;
using MBA.Gaudi.API.Extensions;
using MBA.Gaudi.Core.Domain.Interfaces.Identity;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Mediator;
using MBA.Gaudi.Core.Domain.Notifications;
using MBA.Gaudi.Cursos.Application.Services.Cursos;
using MBA.Gaudi.Cursos.Data.Repositories;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Cursos.Domain.Interfaces.Services;
using MBA.Gaudi.Cursos.Domain.Services;
using MBA.Gaudi.Pagamentos.AntiCorruption;
using MBA.Gaudi.Pagamentos.Data.Repositories;
using MBA.Gaudi.Pagamentos.Domain.Interfaces.Payments;
using MBA.Gaudi.Pagamentos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Pagamentos.Domain.Interfaces.Services;
using MBA.Gaudi.Pagamentos.Domain.Services;
using MBA.Gaudi.Vendas.Data.Repositories;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;

namespace MBA.Gaudi.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterApplicationDependencies(services, configuration);
            RegisterRepositories(services);
            RegisterServices(services);
            return services;
        }

        private static void RegisterApplicationDependencies(IServiceCollection service, IConfiguration configuration)
        {
            //service.AddScoped<IdentityDbContext>();
            //service.AddScoped<CursoContext>();
            //service.AddScoped<PedidoContext>();
            //service.AddScoped<AlunoContext>();
            //service.AddScoped<PagamentoContext>();
            service.AddScoped<INotificador, Notificador>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegisterRepositories(IServiceCollection service)
        {
            service.AddScoped<ICursoRepository, CursoRepository>();
            service.AddScoped<IAulaRepository, AulaRepository>();
            service.AddScoped<IPedidoRepository, PedidoRepository>();
            service.AddScoped<IAlunoRepository, AlunoRepository>();
            service.AddScoped<IMatriculaRepository, MatriculaRepository>();
            service.AddScoped<ICertificadoRepository, CertificadoRepository>();
            service.AddScoped<IPagamentoRepository, PagamentoRepository>();
        }

        private static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IMediatorHandler, MediatorHandler>();
            service.AddScoped<ICursoAppService, CursoAppService>();
            service.AddScoped<ICursoService, CursoService>();
            service.AddScoped<ICertificadoPdfService, CertificadoPdfService>();
            service.AddScoped<IPagamentoService, PagamentoService>();
            service.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            service.AddScoped<IPayPalGateway, PayPalGateway>();
            service.AddScoped<Pagamentos.Domain.Interfaces.Payments.IConfigurationManager, Pagamentos.AntiCorruption.ConfigurationManager>();
            service.AddScoped<IUser, AspNetUser>();
        }
    }
}