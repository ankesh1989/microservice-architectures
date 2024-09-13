using BCommerce.CommonService.API.Queries.Country;
using BCommerce.Shared.Utilities;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private static readonly string ConnectionString = "localhost:6379,abortConnect=false,ConnectTimeout=10000";
        private static readonly ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect(ConnectionString);
        private const string Channel = "Country";

        private readonly IMediator _mediator;
        private readonly ILogger<CountryController> _logger;
        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //[KeycloakAuthorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCountryDto createCountryDto)
        {
            _logger.LogInformation(LogMessages.CreateCountry);
            int countryId = await _mediator.Send(new CreateCountryCommand(createCountryDto));
            if (countryId < 1)
                ExceptionHelper.ThrowCustomException(LogMessages.CreateCountry);

            return Ok();
        }

        //[KeycloakAuthorize(Roles = "Admin")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditCountyDto editCountyDto)
        {
            _logger.LogInformation(LogMessages.EditCountry);
            int countryId = await _mediator.Send(new EditCountryCommand(editCountyDto));
            if (countryId < 1)
                ExceptionHelper.ThrowCustomException(LogMessages.EditCountry);

            return Ok();
        }

        //[KeycloakAuthorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation(LogMessages.DeleteCountry);
            bool isDeleted = await _mediator.Send(new DeleteCountryCommand(id));
            if (!isDeleted)
                ExceptionHelper.ThrowCustomException(LogMessages.DeleteCountry);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetById/{countryId}")]
        public async Task<IActionResult> GetById(int countryId)
        {
            //var subscriber = Connection.GetSubscriber();

            //await subscriber.SubscribeAsync(Channel, (channel, message) =>
            //{
            //    _logger.LogInformation($"Received Message : {0} {1}", channel, message);
            //});

            return Ok(await _mediator.Send(new GetCountryByIdQuery(countryId)));
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetCountriesQuery(model)));
        }
    }
}
