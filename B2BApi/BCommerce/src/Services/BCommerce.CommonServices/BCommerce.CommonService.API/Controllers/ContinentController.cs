
using BCommerce.CommonService.API.DTOs.Continent;
using BCommerce.CommonService.API.Queries.Continent;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ContinentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateContinentDto createContinentDto)
        {
            if (createContinentDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateContinentCommand(createContinentDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditContinentDto editContinentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditContinentCommand(editContinentDto));
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteContinentCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{ContinentId}")]
        public async Task<IActionResult> GetById(int ContinentId)
        {
            return Ok(await _mediator.Send(new GetContinentByIdQuery(ContinentId)));
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetContinentsQuery(model)));
        }
    }
}

