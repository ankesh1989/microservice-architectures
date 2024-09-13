using BCommerce.MasterService.API.DTOs.AgentProfile;
using BCommerce.MasterService.API.Queries.AgentProfile;
using BCommerce.Shared.ValueObjects;

namespace BCommerce.MasterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AgentProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateAgentProfileDto createAgentProfileDto)
        {
            if (createAgentProfileDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateAgentProfileCommand(createAgentProfileDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditAgentProfileDto editAgentProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditAgentProfileCommand(editAgentProfileDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAgentProfileCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{AgentProfileId}")]
        public async Task<IActionResult> GetById(int AgentProfileId)
        {
            return Ok(await _mediator.Send(new GetAgentProfileByIdQuery(AgentProfileId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetAgentProfilesQuery(model)));
        }
    }
}
