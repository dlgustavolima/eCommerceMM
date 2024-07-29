using Core.Mediator;
using Pedidos.Domain.Vouchers;
using WebAPI.Core.Usuario;
using Pedidos.API.Application.Queries;
using Pedidos.Infra;
using Pedidos.Infra.Repository;
using Pedidos.API.Application.Commands;
using FluentValidation.Results;
using MediatR;
using Pedidos.Domain.Pedidos;
using Pedidos.API.Application.Events;

namespace Pedidos.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // API
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IAspNetUser, AspNetUser>();

        // Commands
        services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();    
        
        // Events
        services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

        // Application
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<IVoucherQueries, VoucherQueries>();
        services.AddScoped<IPedidoQueries, PedidoQueries>();

        // Data
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IVoucherRepository, VoucherRepository>();
        services.AddScoped<PedidosContext>();
    }
}
