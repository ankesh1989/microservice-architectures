using Microsoft.Extensions.Configuration;

namespace BCommerce.ExternalServices.Shared.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _weatherApiUrl = string.Empty;
        private readonly string _weatherApiKey = string.Empty;
        public ExternalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _weatherApiUrl = "https://api.openweathermap.org/data/2.5/";
            _weatherApiKey = "f480e7529b71135c8facbe1d3819d49b";
//#pragma warning disable CS8601 // Possible null reference assignment.
//            _weatherApiUrl = _configuration["Logging"];
//#pragma warning restore CS8601 // Possible null reference assignment.
//#pragma warning disable CS8601 // Possible null reference assignment.
//            _weatherApiKey = _configuration["WeatherApiKey"];
//#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public async Task<string> GetWeatherByCity(string city)
        {
            string apiUrl = string.Format("{0}{1}", _weatherApiUrl, $"weather?q={city}&appid={_weatherApiKey}&units=metric");

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response Data: " + responseData);

                return responseData;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");

#pragma warning disable CS8603 // Possible null reference return.
                return response.ReasonPhrase;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

    }
}
