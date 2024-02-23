using System.Net;

namespace TTEcommerce.Core.Infrastructure.Identity;

public class TokenRequester : ITokenRequester
{
    private const string _applicationKey = "ApplicationToken";
    private readonly IMemoryCache _cache;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly HttpClient _httpClient;

    public TokenRequester(IMemoryCache cache, IHttpContextAccessor contextAccessor, IHttpClientFactory factory)
    {
        _cache = cache;
        _contextAccessor = contextAccessor;
        _httpClient = factory.CreateClient();
    }

    // Caching application token
    public async Task<TokenResponse> GetApplicationTokenAsync(TokenIssuerSettings settings)
    {
        TokenResponse tokenResponse = default!;
        var isStoredToken = _cache.TryGetValue(_applicationKey, out tokenResponse);

        if (!isStoredToken)
            tokenResponse = await RequestApplicationTokenAsync(settings);

        if (isStoredToken && IsTokenExpired(tokenResponse))
            tokenResponse = await RequestApplicationTokenAsync(settings);

        return tokenResponse;
    }

    public async Task<TokenResponse> GetUserTokenAsync(TokenIssuerSettings settings, string userName, string password)
    {
        var identityServerAddress = $"{settings.Authority}/connect/token";
        var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = identityServerAddress,
            ClientId = settings.ClientId,
            ClientSecret = settings.ClientSecret,
            Scope = settings.Scope,
            GrantType = "password",
            UserName = userName,
            Password = password
        });

        return response;
    }

    public async Task<string> GetUserTokenFromHttpContextAsync()
    {
        return await _contextAccessor.HttpContext?.GetTokenAsync("access_token");
    }

    private async Task<TokenResponse> RequestApplicationTokenAsync(TokenIssuerSettings settings)
    {
        if (settings is null)
            throw new ArgumentNullException(nameof(settings));

        var identityServerAddress = $"{settings.Authority}/connect/token";
        var tokenResponse = await _httpClient
            .RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = identityServerAddress,
                ClientId = settings.ClientId,
                ClientSecret = settings.ClientSecret,
                Scope = settings.Scope
            });

        if (tokenResponse.HttpStatusCode == HttpStatusCode.OK)
            _cache.Set(_applicationKey, tokenResponse);

        return tokenResponse;
    }

    private bool IsTokenExpired(TokenResponse tokenResponse)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(tokenResponse.AccessToken);

        if (jwtSecurityToken.ValidTo < DateTime.UtcNow.AddSeconds(10))
            return true;

        return false;
    }
}
