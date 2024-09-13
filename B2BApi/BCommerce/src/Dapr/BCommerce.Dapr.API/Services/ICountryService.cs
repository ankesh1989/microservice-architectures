using BCommerce.Dapr.API.Dtos.Country;

namespace BCommerce.Dapr.API.Services
{
    public interface ICountryService
    {
        Task<PagedList<GetCountriesDto>> GetAllCountries(PagingDTO pagingModel);
        Task<GetCountriesDto> GetCountryById(int countryId);
        Task<string> InsertCountry(CreateCountryDto createCountryDto);
        Task<string> UpdateCountry(EditCountyDto editCountyDto);
        Task<string> RemoveCountry(int id);
    }
}