using BCommerce.CommonService.API.DTOs.Role;
using BCommerce.CommonService.API.Queries.Role;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {
            if (createRoleDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateRoleCommand(createRoleDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditRoleDto editRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditRoleCommand(editRoleDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteRoleCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{roleId}")]
        public async Task<IActionResult> GetById(int roleId)
        {
            return Ok(await _mediator.Send(new GetRoleByIdQuery(roleId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return base.Ok(await _mediator.Send(new GetRolesQuery(model)));
        }
    }
}
