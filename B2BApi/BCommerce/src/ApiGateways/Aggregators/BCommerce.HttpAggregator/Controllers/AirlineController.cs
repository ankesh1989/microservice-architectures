using BCommerce.HttpAggregator.Models;
using BCommerce.HttpAggregator.Services;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;
        public AirlineController(IAirlineService airlineervice)
        {
            _airlineService = airlineervice;
        }

        [HttpPost("CreateAirline")]
        public async Task<IActionResult> CreateAirline(BookingCreateRequest request)
        {
            await _airlineService.CreateAirline(request);
            return Ok();
        }
    }
}
