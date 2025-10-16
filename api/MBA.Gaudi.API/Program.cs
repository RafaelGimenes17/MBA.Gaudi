using MBA.Gaudi.API.Configurations;
using MBA.Gaudi.Core.Application;
using MBA.Gaudi.Alunos.Application;
using MBA.Gaudi.Cursos.Application;
using MBA.Gaudi.Pagamentos.Domain;
using MBA.Gaudi.Pagamentos.Application;
using MBA.Gaudi.Vendas.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.AddDatabaseSelector();
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddAuthConfig(builder.Configuration);
builder.Services.AddApiConfig(builder.Configuration);
builder.Services.AddDependencyInjectionConfig(builder.Configuration);

// Configuração de Application Layer (MediatR, FluentValidation, AutoMapper)
builder.Services.AddCoreApplication();
builder.Services.AddAlunosApplication();
builder.Services.AddApplication();
builder.Services.AddPagamentosApplication();
builder.Services.AddPagamentosApplicationHandlers();
builder.Services.AddVendasApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigrationsAndSeedsConfig();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
