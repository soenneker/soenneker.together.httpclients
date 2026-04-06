using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Together.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Together.HttpClients;

///<inheritdoc cref="ITogetherOpenApiHttpClient"/>
public sealed class TogetherOpenApiHttpClient : ITogetherOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://api.together.xyz/v1";

    public TogetherOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(TogetherOpenApiHttpClient), (config: _config, baseUrl: _config["Together:ClientBaseUrl"] ?? _prodBaseUrl), static state =>
        {
            var apiKey = state.config.GetValueStrict<string>("Together:ApiKey");
            string authHeaderName = state.config["Together:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = state.config["Together:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.baseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {authHeaderName, authHeaderValue},
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(TogetherOpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(TogetherOpenApiHttpClient));
    }
}
