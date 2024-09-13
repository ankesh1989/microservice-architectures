using BCommerce.CommonService.API.DTOs.User;
using BCommerce.CommonService.API.Queries.User;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateUserCommand(createUserDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditUserDto editUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditUserCommand(editUserDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{UserId}")]
        public async Task<IActionResult> GetById(int UserId)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(UserId)));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetUsersQuery(model)));
        }
    }
}
