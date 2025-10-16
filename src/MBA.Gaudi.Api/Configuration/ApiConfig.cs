using System.Text.Json.Serialization;

namespace MBA.Gaudi.Api.Configuration
{
    public static class ApiConfig
    {
        /// <summary>
        /// Adiciona a configuração da API ao <see cref="WebApplicationBuilder"/> especificado.
        /// </summary>
        /// <param name="builder">O <see cref="WebApplicationBuilder"/> a ser configurado.</param>
        /// <returns>O <see cref="WebApplicationBuilder"/> configurado.</returns>
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                        .ConfigureApiBehaviorOptions(options =>
                        {
                            options.SuppressModelStateInvalidFilter = true;
                        })
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                        });

            return builder;
        }
    }
}
