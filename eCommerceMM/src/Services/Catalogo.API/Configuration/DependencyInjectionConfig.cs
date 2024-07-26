using Catalogo.API.Data.Repository;
using Catalogo.API.Data;
using Catalogo.API.Models;

namespace Catalogo.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<CatalogoContext>();
    }
}
