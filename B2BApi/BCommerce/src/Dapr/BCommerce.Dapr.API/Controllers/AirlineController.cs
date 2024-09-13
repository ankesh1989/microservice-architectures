using Microsoft.AspNetCore.Mvc;

namespace BCommerce.Dapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;
        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpGet("GetAllAirlines")]
        public async Task<IActionResult> GetAllAirlines([FromQuery] PagingDTO model)
        {
            try
            {
                return Ok(await _airlineService.GetAllAirlines(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAirlineById/{airlineId}")]
        public async Task<IActionResult> GetAirlineById(int airlineId)
        {
            try
            {
                return Ok(await _airlineService.GetAirlineById(airlineId));
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}