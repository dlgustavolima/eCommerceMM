using Carrinho.API.Configuration;
using Carrinho.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarrinhoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApiConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.RegisterServices();
builder.Services.AddMessageBusConfiguration(builder.Configuration);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", true, true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
.AddEnvironmentVariables();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);
app.UseAuthConfiguration();
app.UseSwaggerConfiguration();
app.MapControllers();

app.Run();
