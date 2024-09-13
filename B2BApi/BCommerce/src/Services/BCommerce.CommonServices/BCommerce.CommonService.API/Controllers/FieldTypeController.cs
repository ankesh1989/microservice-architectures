using BCommerce.CommonService.API.DTOs.FieldType;
using BCommerce.CommonService.API.Queries.FieldType;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FieldTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateFieldTypeDto createFieldTypeDto)
        {
            if (createFieldTypeDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateFieldTypeCommand(createFieldTypeDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditFieldTypeDto editFieldTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditFieldTypeCommand(editFieldTypeDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFieldTypeCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{FieldTypeId}")]
        public async Task<IActionResult> GetById(int FieldTypeId)
        {
            return Ok(await _mediator.Send(new GetFieldTypeByIdQuery(FieldTypeId)));
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetFieldTypesQuery(model)));
        }
    }
}