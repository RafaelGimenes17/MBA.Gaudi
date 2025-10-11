using MBA.Gaudi.Api.Configuration;
using MBA.Gaudi.Ioc.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddDataContextPool();
builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddSwaggerConfig()
    //.AddDatabaseSelector()
    .AddIdentityConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Production");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseDbMigrationHelper();

app.Run();