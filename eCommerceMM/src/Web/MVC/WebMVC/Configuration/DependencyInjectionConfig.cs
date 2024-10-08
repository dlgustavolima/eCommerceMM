﻿using WebAPI.Core.Usuario;
using WebMVC.Extensions;
using WebMVC.Services;
using WebMVC.Services.Handlers;
using WebAPI.Core.Extensions;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System.Collections.Generic;

namespace WebMVC.Configuration;

public static class DependencyInjectionConfig
{

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAspNetUser, AspNetUser>();

        #region HttpServices

        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AllowSelfSignedCertificate()
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        services.AddHttpClient<ICatalogoService, CatalogoService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            .AllowSelfSignedCertificate()
            .AddPolicyHandler(PollyExtensions.EsperarTentar())
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        services.AddHttpClient<IComprasBffService, ComprasBffService>()
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
        
        #endregion
    }
}

public class PollyExtensions
{
    public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
    {
        var retry = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10),
            }, (outcome, timespan, retryCount, context) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Tentando pela {retryCount} vez!");
                Console.ForegroundColor = ConsoleColor.White;
            });

        return retry;
    }
}
