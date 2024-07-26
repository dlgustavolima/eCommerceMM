using Bff.Compras.Extensions;

namespace Bff.Compras.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.Configure<AppServicesSettings>(configuration);
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        return app;
    }
}
