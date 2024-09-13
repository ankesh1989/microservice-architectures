using BCommerce.HttpAggregator.Models;
using BCommerce.HttpAggregator.Services;
using BCommerce.HttpAggregator.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [Route("GetCountries")]
        [HttpGet]
        public async Task<IActionResult> GetCountries([FromQuery] PagingDTO model)
        {
            var result = await _countryService.GetCountries(model);
            return Ok(result);
        }

        [HttpGet("GetCountryById/{countryId}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            string result = await _countryService.GetCountryById(countryId);
            if(string.IsNullOrEmpty(result))
                return NoContent();
           
            return Ok(result);
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry(CreateCountryDto country)
        {
            var result = await _countryService.CreateCountry(country);
            return Ok(result);
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(EditCountryDto country)
        {
            var result = await _countryService.UpdateCountry(country);
            return Ok(result);
        }

        [HttpDelete("RemoveCountry/{id}")]
        public async Task<IActionResult> RemoveCountry(int id)
        {
            var result = await _countryService.RemoveCountry(id);
            return Ok(result);
        }
    }
}
