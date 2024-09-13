using BCommerce.HttpAggregator.Models;

namespace BCommerce.HttpAggregator.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _airlineAddress = string.Empty;
        public AirlineService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient=httpClient;
            _configuration=configuration;
            _airlineAddress = _configuration["AirlineBaseAddress"];
        }
        public async Task CreateAirline(BookingCreateRequest request)
        {
            string apiUrl = string.Format("{0}{1}", _airlineAddress, "api/Airline/CreateAirline");

            var res = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = JsonContent.Create(request)
            };
            var response = await _httpClient.SendAsync(res);
            response.EnsureSuccessStatusCode();
        }
    }
}
