using BCommerce.Dapr.API.Dtos.Airline;

namespace BCommerce.Dapr.API.Services
{
    public interface IAirlineService
    {
        Task<PagedList<GetAirlineDto>> GetAllAirlines(PagingDTO pagingModel);
        Task<GetAirlineDto> GetAirlineById(int airlineId);
    }
}