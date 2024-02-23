namespace TTEcommerce.Core.Infrastructure.Integration;

public interface IIntegrationHttpService
{
    Task<IntegrationHttpResponse> PostAsync(string path, object request);
    Task<IntegrationHttpResponse> PutAsync(string path, object? request = null);
    Task<IntegrationHttpResponse> DeleteAsync(string path, object? request = null);
    Task<IntegrationHttpResponse<TResponse>> FilterAsync<TResponse>(string path, object request) where TResponse : class;
    Task<IntegrationHttpResponse<TResponse>> GetAsync<TResponse>(string path) where TResponse : class;
}
