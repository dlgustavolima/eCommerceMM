using Catalogo.API.Configuration;
using Catalogo.API.Data;
using WebAPI.Core.Identidade;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApiConfiguration();
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
