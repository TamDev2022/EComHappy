using Application.Options.Commands;
using Application.Options.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertOptionCommand insertProductOption)
        {
            var result = await _mediator.Send(insertProductOption);

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("Insert-With-Value")]
        [HttpPost]
        public async Task<IActionResult> InsertWithValueAsync([FromBody] InsertOptionWithValueCommand insertProductOptionWithValue)
        {
            var result = await _mediator.Send(insertProductOptionWithValue);

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("Options")]
        [HttpGet]
        public async Task<IActionResult> GetOptionsAsync()
        {
            var result = await _mediator.Send(new GetOptionsQuery());

            return new JsonResult(new { success = true, data = result });
        }
    }
}
