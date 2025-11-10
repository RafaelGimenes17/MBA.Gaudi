using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace MBA.Gaudi.GestaoConteudo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registrar MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Registrar FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Registrar AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
