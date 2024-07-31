using WebMVC.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebMVC.Configuration;

public static class WebAppConfiguration
{

    public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
            ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        services.Configure<AppSettings>(configuration);
    }

    public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/erro/500");
            app.UseStatusCodePagesWithRedirects("/erro/{0}");
            app.UseHsts();
        }

        var supportedCultures = new[] { new CultureInfo("pt-BR") };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("pt-BR"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRouting();
    }

}
