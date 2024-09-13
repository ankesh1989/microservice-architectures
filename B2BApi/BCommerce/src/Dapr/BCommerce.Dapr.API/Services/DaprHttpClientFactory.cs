namespace BCommerce.Dapr.API.Services
{
    public class DaprHttpClientFactory : IDaprHttpClientFactory
    {
        public HttpClient CreateHttpClient(string apiName)
        {
            return DaprClient.CreateInvokeHttpClient(apiName);
        }
    }
}