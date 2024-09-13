using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.KeyCloak.API.Controllers
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

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new GetUserQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new CreateUserCommand(createUserDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new UpdateUserCommand(updateUserDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new DeleteUserCommand(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ResetUserPassword")]
        public async Task<IActionResult> ResetUserPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new ResetUserPasswordCommand(resetPasswordDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}