using Microsoft.AspNetCore.Mvc;
using MultiCrud.Application.Abstractions.Services;
using MultiCrud.Application.InOut;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCrud.Application.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplicationService _personAppService;
        public PersonController(IPersonApplicationService personAppService)
        {
            _personAppService = personAppService ?? throw new ArgumentNullException(nameof(personAppService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _personAppService.GetAllAsync();
            if (response.Any())
                return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _personAppService.GetByIdAsync(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] PersonInput input)
        {
            await _personAppService.InsertAsync(input);
            return Created(Request.Path, new { success = true });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonInput input)
        {
            await _personAppService.UpdateAsync(input);
            return Accepted();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _personAppService.RemoveAsync(id);
            return Ok();
        }
    }
}
