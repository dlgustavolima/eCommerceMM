using Cliente.API.Application.Commands;
using Cliente.API.Data.Repository;
using Cliente.API.Data;
using Cliente.API.Models;
using Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Cliente.API.Application.Events;
using Cliente.API.Services;
using WebAPI.Core.Usuario;

namespace Cliente.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAspNetUser, AspNetUser>();

        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
        services.AddScoped<IRequestHandler<AdicionarEnderecoCommand, ValidationResult>, ClienteCommandHandler>();

        services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ClientesContext>();
    }
}
