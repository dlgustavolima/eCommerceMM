using Cliente.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Cliente.API.Configuration;

public static class ApiConfig
{

    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddDbContext<ClientesContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddCors(options =>
        {
            options.AddPolicy("Total",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseCors("Total");

        app.UseHttpsRedirection();

        return app;
    }

}
