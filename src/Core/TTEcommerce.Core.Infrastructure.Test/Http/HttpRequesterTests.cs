namespace TTEcommerce.Core.Infrastructure.Test.Http;

public class HttpRequesterTests
{
    private readonly IHttpClientFactory _httpClientFactory = Substitute.For<IHttpClientFactory>();

    private readonly Uri _url = new("http://test.com");

    [Fact]
    public async Task GetAsync_ShouldReturnResponse()
    {
        // Given
        var aggregateId = new DummyAggregateId(Guid.NewGuid());
        var dummyResponse = new List<DummyAggregateRoot>
        {
            new(aggregateId),
            new(aggregateId),
            new(aggregateId)
        };

        var dummyResponseJson = JsonConvert.SerializeObject(dummyResponse);
        var messageHandler = new MockHttpMessageHandler(dummyResponseJson, HttpStatusCode.OK);
        var httpClient = new HttpClient(messageHandler)
        {
            BaseAddress = _url
        };

        _httpClientFactory.CreateClient()
            .Returns(httpClient);

        var requester = new HttpRequester(_httpClientFactory);

        // When
        var response = await requester
            .GetAsync<List<DummyAggregateRoot>>(_url.AbsoluteUri);

        // Then
        Assert.NotNull(response);
        response!.Count.Should().Be(dummyResponse.Count);
    }

    [Fact]
    public async Task PostAsync_ShouldReturnResponse()
    {
        // Given        
        var dummyResponse = JsonConvert
            .SerializeObject(new IntegrationHttpResponse { Success = true });

        var messageHandler = new MockHttpMessageHandler(dummyResponse, HttpStatusCode.OK);
        var httpClient = new HttpClient(messageHandler)
        {
            BaseAddress = _url
        };
        _httpClientFactory.CreateClient(Arg.Any<string>())
            .Returns(httpClient);

        var requester = new HttpRequester(_httpClientFactory);

        // When
        var response = await requester.PostAsync<IntegrationHttpResponse>(_url.AbsoluteUri, new object());

        // Then
        Assert.NotNull(response);
        response!.Success.Should().BeTrue();
    }

    [Fact]
    public async Task PutAsync_ShouldReturnResponse()
    {
        // Given        
        var dummyResponse = JsonConvert
            .SerializeObject(new IntegrationHttpResponse { Success = true });

        var messageHandler = new MockHttpMessageHandler(dummyResponse, HttpStatusCode.OK);
        var httpClient = new HttpClient(messageHandler)
        {
            BaseAddress = _url
        };
        _httpClientFactory.CreateClient(Arg.Any<string>())
            .Returns(httpClient);

        var requester = new HttpRequester(_httpClientFactory);

        // When
        var response = await requester
            .PutAsync<IntegrationHttpResponse>(_url.AbsoluteUri, new object());

        // Then
        Assert.NotNull(response);
        response!.Success.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnResponse()
    {
        // Given        
        var dummyResponse = JsonConvert
            .SerializeObject(new IntegrationHttpResponse { Success = true });

        var messageHandler = new MockHttpMessageHandler(dummyResponse, HttpStatusCode.OK);
        var httpClient = new HttpClient(messageHandler)
        {
            BaseAddress = _url
        };
        _httpClientFactory.CreateClient(Arg.Any<string>())
            .Returns(httpClient);

        var requester = new HttpRequester(_httpClientFactory);

        // When
        var response = await requester.DeleteAsync<IntegrationHttpResponse>(_url.AbsoluteUri);

        // Then
        Assert.NotNull(response);
        response!.Success.Should().BeTrue();
    }
}
