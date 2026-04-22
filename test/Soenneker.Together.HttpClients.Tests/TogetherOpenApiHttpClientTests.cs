using Soenneker.Together.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Together.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TogetherOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ITogetherOpenApiHttpClient _httpclient;

    public TogetherOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITogetherOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
