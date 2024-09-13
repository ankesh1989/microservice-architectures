using BCommerce.HttpAggregator.Models;

namespace BCommerce.HttpAggregator.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private  readonly string _supplierAddress = string.Empty;
        public SupplierService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _supplierAddress = _configuration["CommonBaseAddress"];

        }
        public async Task GetUserById(int userId)
        {
            string apiUrl = string.Format("{0}{1}", _supplierAddress, $"api/Supplier/GetAllListByUserId/{userId}");

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response Data: " + responseData);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        public async Task CreateSupplier(CreateSupplierDto supplier)
        {

            string apiUrl = string.Format("{0}{1}", _supplierAddress, "api/Supplier/Create");

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = JsonContent.Create(supplier)
            };
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

    }
}
