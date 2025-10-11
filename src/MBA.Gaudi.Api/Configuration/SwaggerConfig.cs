using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MBA.Gaudi.Api.Configuration
{
    /// <summary>
    /// Classe estática responsável pela configuração do Swagger para a aplicação.
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Adiciona a configuração do Swagger ao <see cref="WebApplicationBuilder"/> especificado.
        /// </summary>
        /// <param name="builder">O builder da aplicação web.</param>
        /// <returns>O <see cref="WebApplicationBuilder"/> atualizado.</returns>
        public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo()
                {   
                    Title = "API Gaudi",
                    Version = "v1",
                    Description = "Projeto MBA: API - Gaudi",
                    Contact = new OpenApiContact()
                    {
                        Name = "Rafael Fernando Gimenes",
                        Email = "rafael@gmail.com"
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                });

            });

            return builder;
        }
    }
}
