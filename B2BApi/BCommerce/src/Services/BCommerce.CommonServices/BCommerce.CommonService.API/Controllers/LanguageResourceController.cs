using BCommerce.CommonService.API.DTOs.LanguageResorce;
using BCommerce.CommonService.API.Queries.LanguageResource;
using BCommerce.Shared.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCommerce.CommonService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageResourceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageResourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateLanguageResourceDto createLanguageResourceDto)
        {
            if (createLanguageResourceDto == null)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateLanguageResourceCommand(createLanguageResourceDto));

            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditLanguageResourceDto editLanguageResourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new EditLanguageResourceCommand(editLanguageResourceDto));
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLanaguageResourceCommand(id));

            return NoContent();
        }

        [HttpGet("GetById/{languageResourceId}")]
        public async Task<IActionResult> GetById(int languageResourceId)
        {
            return Ok(await _mediator.Send(new GetLanguageResourceByIdQuery(languageResourceId)));
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingDTO model)
        {
            return Ok(await _mediator.Send(new GetLanguageResourcesQuery(model)));
        }
    }
}

    

