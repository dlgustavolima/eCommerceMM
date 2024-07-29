using Microsoft.OpenApi.Models;

namespace Identidade.API.Configuration;

public static class SwaggerConfig
{

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "eCommerceMM API",
                Description = "Ajudar no entendimento das estruturas de cada funcionalidade",
                Contact = new OpenApiContact() { Name = "Gustavo" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });

        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

}
