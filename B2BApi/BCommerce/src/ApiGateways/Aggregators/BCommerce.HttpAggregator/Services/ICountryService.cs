using BCommerce.HttpAggregator.Models;
using BCommerce.HttpAggregator.ValueObjects;

namespace BCommerce.HttpAggregator.Services
{
    public interface ICountryService
    {
        Task<string> GetCountries(PagingDTO model);
        Task<string> GetCountryById(int countryId);
        Task<string> CreateCountry(CreateCountryDto country);
        Task<string> UpdateCountry(EditCountryDto country);
        Task<string> RemoveCountry(int id);
    }
}