using Application.OptionValues.Commands;
using Application.OptionValues.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OptionValueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OptionValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertOptionValueCommand insertProductOptionValue)
        {
            var result = await _mediator.Send(insertProductOptionValue);

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("OptionValues")]
        [HttpGet]
        public async Task<IActionResult> GetProductOptionValuesAsync()
        {
            var result = await _mediator.Send(new GetOptionValuesQuery());

            return new JsonResult(new { success = true, data = result });
        }
    }
}
