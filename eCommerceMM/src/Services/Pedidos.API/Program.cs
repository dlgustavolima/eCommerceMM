using Pedidos.API.Configuration;
using WebAPI.Core.Identidade;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Pedidos.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PedidosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => { options.MigrationsAssembly("Pedidos.API"); }));

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
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

app.UseHttpsRedirection();
app.UseAuthConfiguration();
app.UseSwaggerConfiguration();

app.MapControllers();

app.Run();
