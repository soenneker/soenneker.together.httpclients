using Soenneker.Together.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Together.HttpClients.Tests;

[Collection("Collection")]
public sealed class TogetherOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ITogetherOpenApiHttpClient _httpclient;

    public TogetherOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ITogetherOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
