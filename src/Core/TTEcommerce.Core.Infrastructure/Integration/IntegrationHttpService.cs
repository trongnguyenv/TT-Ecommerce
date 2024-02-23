namespace TTEcommerce.Core.Infrastructure.Integration;

public class IntegrationHttpService : IIntegrationHttpService
{
    private readonly IHttpRequester _httpRequester;
    private readonly IntegrationHttpSettings _integrationSettings;
    private readonly TokenIssuerSettings _tokenIssuerSettings;
    private readonly ITokenRequester _tokenRequester;

    public IntegrationHttpService(IHttpRequester httpRequester, ITokenRequester tokenRequester,
        TokenIssuerSettings tokenIssuerSettings, IntegrationHttpSettings integrationSettings)
    {
        if (tokenIssuerSettings is null)
            throw new ArgumentNullException(nameof(tokenIssuerSettings));
        if (integrationSettings is null)
            throw new ArgumentNullException(nameof(integrationSettings));

        _httpRequester = httpRequester;
        _tokenRequester = tokenRequester;
        _tokenIssuerSettings = tokenIssuerSettings;
        _integrationSettings = integrationSettings;
    }

    public async Task<IntegrationHttpResponse> PostAsync(string path, object request)
    {
        var response = await _httpRequester.PostAsync<IntegrationHttpResponse>(
            $"{_integrationSettings.ApiGatewayBaseUrl}/{path}",
            request,
            await GetAccessToken());

        return response;
    }

    public async Task<IntegrationHttpResponse> PutAsync(string path, object? request = null)
    {
        var response = await _httpRequester.PutAsync<IntegrationHttpResponse>(
            $"{_integrationSettings.ApiGatewayBaseUrl}/{path}",
            request,
            await GetAccessToken());
        return response;
    }

    public async Task<IntegrationHttpResponse> DeleteAsync(string path, object? request = null)
    {
        var response = await _httpRequester.DeleteAsync<IntegrationHttpResponse>(
            $"{_integrationSettings.ApiGatewayBaseUrl}/{path}",
            request,
            await GetAccessToken());

        return response;
    }

    public async Task<IntegrationHttpResponse<TResponse>> FilterAsync<TResponse>(string path, object request)
        where TResponse : class
    {
        var response = await _httpRequester.PostAsync<IntegrationHttpResponse<TResponse>>(
            $"{_integrationSettings.ApiGatewayBaseUrl}/{path}",
            request,
            await GetAccessToken());

        return response;
    }

    public async Task<IntegrationHttpResponse<TResponse>> GetAsync<TResponse>(string path) where TResponse : class
    {
        var response = await _httpRequester.GetAsync<IntegrationHttpResponse<TResponse>>(
            $"{_integrationSettings.ApiGatewayBaseUrl}/{path}",
            await GetAccessToken());

        return response;
    }

    private async Task<string> GetAccessToken()
    {
        var tokenResponse = await _tokenRequester
            .GetApplicationTokenAsync(_tokenIssuerSettings);
        return tokenResponse?.AccessToken ?? string.Empty;
    }
}
