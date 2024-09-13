using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.KeyCloak.API.Controllers
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

        [HttpGet("GetRoles")]
        public async Task<IActionResult>  GetAll()
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new GetRoleQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new CreateRoleCommand(createRoleDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new UpdateRoleCommand(updateRoleDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new DeleteRoleCommand(roleId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}