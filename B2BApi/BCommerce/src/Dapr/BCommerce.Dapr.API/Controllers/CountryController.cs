using BCommerce.Dapr.API.Dtos.Country;
using BCommerce.Shared.CustomAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BCommerce.Dapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;

        public CountryController(ILogger<CountryController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries([FromQuery] PagingDTO model)
        {
            _logger.LogInformation($"Returning data {JsonSerializer.Serialize("test")} ");
            return Ok(await _countryService.GetAllCountries(model));
        }

        [AllowAnonymous]
        [HttpGet("GetCountryById/{countryId}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            try
            {
                return Ok(await _countryService.GetCountryById(countryId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       // [KeycloakAuthorize(Roles = "Admin")]
        [HttpPost("Create")]

        public async Task<IActionResult> Create(CreateCountryDto createCountryDto)
        {
            string data = await _countryService.InsertCountry(createCountryDto);

            _logger.LogInformation($"Create data {JsonSerializer.Serialize(data)} ");

            if (data == Constants.SavedCountry)
                return Ok(data);
            else
                return BadRequest(data);
        }

      //  [KeycloakAuthorize(Roles = "Admin")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditCountyDto editCountyDto)
        {
            string data = await _countryService.UpdateCountry(editCountyDto);

            _logger.LogInformation($"Edit data {JsonSerializer.Serialize(data)} ");

            if (data == Constants.UpdatedCountry)
                return Ok(data);
            else
                return BadRequest(data);
        }

       // [KeycloakAuthorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string data = await _countryService.RemoveCountry(id);

            _logger.LogInformation($"Delete data {JsonSerializer.Serialize(data)} ");

            if (data == Constants.RemovedCountry)
                return Ok(data);
            else
                return BadRequest(data);
        }
    }
}