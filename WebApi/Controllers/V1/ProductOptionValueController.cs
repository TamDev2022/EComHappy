using Application.Commands.ProductOptions;
using Application.Commands.ProductOptionValues;
using Application.Queries.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductOptionValueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductOptionValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertProductOptionValueCommand insertProductOptionValue)
        {
            var result = await _mediator.Send(insertProductOptionValue);

            return new JsonResult(new { success = true, data = result });
        }
    }
}
