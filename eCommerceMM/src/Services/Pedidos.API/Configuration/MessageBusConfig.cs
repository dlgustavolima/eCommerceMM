using Core.Utils;
using FB.Pedidos.API.Services;
using MessageBus;
using Pedidos.API.Services;

namespace Pedidos.API.Configuration;

public static class MessageBusConfig
{
    public static void AddMessageBusConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
            .AddHostedService<PedidoOrquestradorIntegrationHandler>()
            .AddHostedService<PedidoIntegrationHandler>();
    }
}
