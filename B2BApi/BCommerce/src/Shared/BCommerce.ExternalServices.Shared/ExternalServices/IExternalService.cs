namespace BCommerce.ExternalServices.Shared.ExternalServices
{
    public interface IExternalService
    {
        Task<string> GetWeatherByCity(string city);
    }
}
