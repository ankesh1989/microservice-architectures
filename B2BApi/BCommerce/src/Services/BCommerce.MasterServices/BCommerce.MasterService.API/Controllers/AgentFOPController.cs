using BCommerce.MasterService.API.DTOs.AgentFOP;
using BCommerce.MasterService.API.Queries.AgentFOP;
using BCommerce.Shared.ValueObjects;

namespace BCommerce.MasterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentFOPController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AgentFOPController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateAgentFOPDto createAgentFOPDto)
        {
            if (createAgentFOPDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateAgentFOPCommand(createAgentFOPDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditAgentFOPDto editAgentFOPDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditAgentFOPCommand(editAgentFOPDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAgentFOPCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{agentFOPId}")]
        public async Task<IActionResult> GetById(int agentFOPId)
        {
            return Ok(await _mediator.Send(new GetAgentFOPsByIdQuery(agentFOPId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return base.Ok(await _mediator.Send(new GetAgentFOPsQuery(model)));
        }
    }
}
