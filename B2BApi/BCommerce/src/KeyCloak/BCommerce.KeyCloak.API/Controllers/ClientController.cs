using BCommerce.KeyCloak.API.Command.Create;
using BCommerce.KeyCloak.API.DTOs;
using BCommerce.KeyCloak.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.KeyCloak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new GetClientQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(BusinessDto businessDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new CreateClientCommand(businessDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateClient")]
        public async Task<IActionResult> UpdateClient(UpdateBusinessDto businessDto)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new UpdateClientCommand(businessDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteClient")]
        public async Task<IActionResult> DeleteClient(string clienId)
        {
            try
            {
                return new OkObjectResult(await _mediator.Send(new DeleteClientCommand(clienId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}