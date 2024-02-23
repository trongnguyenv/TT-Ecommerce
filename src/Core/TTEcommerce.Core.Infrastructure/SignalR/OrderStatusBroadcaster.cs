namespace TTEcommerce.Core.Infrastructure.SignalR;

public class OrderStatusBroadcaster : IOrderStatusBroadcaster
{
    private readonly IHttpRequester _httpRequester;
    private readonly IntegrationHttpSettings _integrationHttpSettings;
    private readonly TokenIssuerSettings _tokenIssuerSettings;
    private readonly ITokenRequester _tokenRequester;

    public OrderStatusBroadcaster(IHttpRequester httpRequester, ITokenRequester tokenRequester,
        TokenIssuerSettings tokenIssuerSettings, IntegrationHttpSettings integrationHttpSettings)
    {
        if (tokenIssuerSettings is null)
            throw new ArgumentNullException(nameof(tokenIssuerSettings));
        if (integrationHttpSettings is null)
            throw new ArgumentNullException(nameof(integrationHttpSettings));

        _httpRequester = httpRequester;
        _tokenRequester = tokenRequester;
        _tokenIssuerSettings = tokenIssuerSettings;
        _integrationHttpSettings = integrationHttpSettings;
    }

    public async Task UpdateOrderStatus(UpdateOrderStatusRequest request)
    {
        var tokenResponse = await _tokenRequester
            .GetApplicationTokenAsync(_tokenIssuerSettings);

        await _httpRequester.PostAsync<IntegrationHttpResponse>(
            $"{_integrationHttpSettings.ApiGatewayBaseUrl}/api/signalr/updateorderstatus",
            request,
            tokenResponse.AccessToken);
    }
}
