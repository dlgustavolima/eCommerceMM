using Bff.Compras.Configuration;
using WebAPI.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices();
builder.Services.AddMessageBusConfiguration(builder.Configuration);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", true, true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
.AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<WebApplicationBuilder>();
}

var app = builder.Build();

app.UseApiConfiguration(app.Environment);
app.UseAuthConfiguration();
app.UseSwaggerConfiguration();

app.MapControllers();

app.Run();
