using BCommerce.CommonService.API.Queries.City;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    //[KeycloakAuthorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCityDto createCityDto)
        {
            if (createCityDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateCityCommand(createCityDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditCityDto editCityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditCityCommand(editCityDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCityCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{cityId}")]
        public async Task<IActionResult> GetById(int cityId)
        {
            return Ok(await _mediator.Send(new GetCityByIdQuery(cityId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetCitiesQuery(model)));
        }
    }
}
