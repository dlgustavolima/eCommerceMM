using Identidade.API.Services;
using WebAPI.Core.Usuario;

namespace Identidade.API.Configuration;

public static class ApiConfig
{

    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddScoped<AuthenticationService>();
        services.AddScoped<IAspNetUser, AspNetUser>();

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

        app.UseJwksDiscovery();

        return app;
    }
}
