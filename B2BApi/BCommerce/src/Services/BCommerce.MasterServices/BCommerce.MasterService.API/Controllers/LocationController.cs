using BCommerce.MasterService.API.DTOs.Location;
using BCommerce.MasterService.API.Queries.Location;
using BCommerce.Shared.ValueObjects;

namespace BCommerce.MasterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateLocationDto createLocationDto)
        {
            if (createLocationDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateLocationCommand(createLocationDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditLocationDto editLocationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditLocationCommand(editLocationDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLocationCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{locationId}")]
        public async Task<IActionResult> GetById(int locationId)
        {
            return Ok(await _mediator.Send(new GetLocationByIdQuery(locationId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return base.Ok(await _mediator.Send(new GetLocationsQuery(model)));
        }
    }
}
