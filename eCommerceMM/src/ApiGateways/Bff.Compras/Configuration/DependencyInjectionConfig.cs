using Bff.Compras.Extensions;
using Bff.Compras.Services;
using Polly;
using WebAPI.Core.Extensions;
using WebAPI.Core.Usuario;

namespace Bff.Compras.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAspNetUser, AspNetUser>();

        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICatalogoService, CatalogoService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AllowSelfSignedCertificate()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        services.AddHttpClient<ICarrinhoService, CarrinhoService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AllowSelfSignedCertificate()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        services.AddHttpClient<IPedidoService, PedidoService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AllowSelfSignedCertificate()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        services.AddHttpClient<IClienteService, ClienteService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AllowSelfSignedCertificate()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
    }
}