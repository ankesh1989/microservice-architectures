namespace BCommerce.Dapr.API.Services
{
    public interface IDaprHttpClientFactory
    {
        HttpClient CreateHttpClient(string apiName);
    }
}