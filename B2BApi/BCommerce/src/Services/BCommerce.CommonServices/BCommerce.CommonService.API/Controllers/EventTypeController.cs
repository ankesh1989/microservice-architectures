using BCommerce.CommonService.API.DTOs.EventType;
using BCommerce.CommonService.API.Queries.EventType;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateEventTypeDto createEventTypeDto)
        {
            if (createEventTypeDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateEventTypeCommand(createEventTypeDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditEventTypeDto editEventTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditEventTypeCommand(editEventTypeDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEventTypeCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{EventTypeId}")]
        public async Task<IActionResult> GetById(int EventTypeId)
        {
            return Ok(await _mediator.Send(new GetEventTypeIdQuery(EventTypeId)));
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetEventTypesQuery(model)));
        }
    }
}
