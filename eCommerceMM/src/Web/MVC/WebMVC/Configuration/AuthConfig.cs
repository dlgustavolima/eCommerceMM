using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebMVC.Configuration;

public static class AuthConfig
{

    public static void AddAuthConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/erro/403";
            });
    }

    public static void UseAuthConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

}
