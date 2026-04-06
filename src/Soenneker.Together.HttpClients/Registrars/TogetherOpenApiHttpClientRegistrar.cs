using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Together.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Together.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class TogetherOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="TogetherOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTogetherOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ITogetherOpenApiHttpClient, TogetherOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TogetherOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTogetherOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ITogetherOpenApiHttpClient, TogetherOpenApiHttpClient>();

        return services;
    }
}
