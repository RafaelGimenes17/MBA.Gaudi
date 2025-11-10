using MBA.Gaudi.GestaoAlunos.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MBA.Gaudi.GestaoAlunos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAlunosApplication(this IServiceCollection services)
        {
            // Registrar MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Registrar FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Registrar serviços de aplicação
            services.AddScoped<IMatriculaService, MatriculaService>();

            return services;
        }
    }
}
