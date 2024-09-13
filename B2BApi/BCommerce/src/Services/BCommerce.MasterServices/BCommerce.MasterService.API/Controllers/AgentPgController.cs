using BCommerce.MasterService.API.DTOs.AgentPg;
using BCommerce.MasterService.API.Queries.AgentPG;
using BCommerce.Shared.ValueObjects;

namespace BCommerce.MasterService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentPgController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AgentPgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateAgentPgDto createAgentPgDto)
        {
            if (createAgentPgDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateAgentPgCommand(createAgentPgDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditAgentPgDto editAgentPgDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditAgentPgCommand(editAgentPgDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAgentPgCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{agentPgId}")]
        public async Task<IActionResult> GetById(int agentPgId)
        {
            return Ok(await _mediator.Send(new GetAgentPGByIdQuery(agentPgId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return base.Ok(await _mediator.Send(new GetAgentPGsQuery(model)));
        }
    }
}
