[![](https://img.shields.io/nuget/v/soenneker.together.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.together.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.together.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.together.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.together.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.together.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.together.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.together.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Together.HttpClients
Provides a cached `HttpClient` configured for Together AI's bearer-authenticated API.

## Installation

```bash
dotnet add package Soenneker.Together.HttpClients
```

## Configuration

```json
{
  "Together": {
    "ApiKey": "your-api-key"
  }
}
```

The default base URL is `https://api.together.ai/v1/`. Set `Together:ClientBaseUrl` to override it.

Requests use `Authorization: Bearer {token}` by default. For a different scheme, set `Together:AuthHeaderName` and `Together:AuthHeaderValueTemplate`; `{token}` is replaced with `Together:ApiKey`.

## Registration

```csharp
using Soenneker.Together.HttpClients.Registrars;

services.AddTogetherOpenApiHttpClientAsSingleton();
```

Use `AddTogetherOpenApiHttpClientAsScoped()` when the wrapper should follow the current scope. Each wrapper owns its cached client entry and removes that client when disposed.

## Usage

```csharp
using Soenneker.Together.HttpClients.Abstract;

HttpClient client = await togetherHttpClient.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("models", cancellationToken);
response.EnsureSuccessStatusCode();
```

Reuse the returned client. Do not dispose it directly; the wrapper owns its cached client entry.
