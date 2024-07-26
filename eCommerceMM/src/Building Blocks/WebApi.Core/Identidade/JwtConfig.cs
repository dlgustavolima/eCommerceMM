using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.JwtExtensions;

namespace WebAPI.Core.Identidade;

public static class JwtConfig
{
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<AppSettings>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            bearerOptions.RequireHttpsMetadata = true;
            bearerOptions.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
            bearerOptions.SaveToken = true;
            bearerOptions.SetJwksOptions(new JwkOptions(appSettings.AutenticacaoJwksUrl));
        });

        return services;
    }

    public static IApplicationBuilder UseAuthConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

}
