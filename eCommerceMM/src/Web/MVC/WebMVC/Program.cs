using WebMVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json", true, true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
.AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<WebApplicationBuilder>();
}

builder.Services.AddAuthConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();

app.UseForwardedHeaders();
app.UseAuthConfiguration();
app.UseMvcConfiguration(builder.Environment);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogo}/{action=Index}/{id?}");

app.Run();
