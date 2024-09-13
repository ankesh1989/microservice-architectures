using BCommerce.CommonService.API.Queries.State;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateStateDto createStateDto)
        {
            if (createStateDto == null)
            {
                return BadRequest();
            }
            await _mediator.Send(new CreateStateCommand(createStateDto));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditStateDto editStateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditStateCommand(editStateDto));
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteStateCommand(id));

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("GetById/{stateId}")]
        public async Task<IActionResult> GetById(int stateId)
        {
            return Ok(await _mediator.Send(new GetStateByIdQuery(stateId)));
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetStatesQuery(model)));
        }
    }
}