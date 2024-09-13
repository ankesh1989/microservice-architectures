using BCommerce.CommonService.API.DTOs.UserPrivilege;
using BCommerce.CommonService.API.Queries.UserPrivilege;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPrivilegeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserPrivilegeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserPrivilegeDto createUserPrivilegeDto)
        {
            if (createUserPrivilegeDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateUserPrivilegeCommand(createUserPrivilegeDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditUserPrivilegeDto editUserPrivilegeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditUserPrivilegeCommand(editUserPrivilegeDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserPrivilegeCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{UserPrivilegeId}")]
        public async Task<IActionResult> GetById(int UserPrivilegeId)
        {
            return Ok(await _mediator.Send(new GetUserPrivilegeByIdQuery(UserPrivilegeId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetUserPrivilegesQuery(model)));
        }
    }
}
