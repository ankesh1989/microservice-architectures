using BCommerce.HttpAggregator.Models;

namespace BCommerce.HttpAggregator.Services
{
    public interface IAirlineService
    {
        Task CreateAirline(BookingCreateRequest request);
    }
}
