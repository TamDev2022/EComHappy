using Application.Commands.ProductOptions;
using Application.Queries.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductOptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductOptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertProductOptionCommand insertProductOption)
        {
            var result = await _mediator.Send(insertProductOption);

            return new JsonResult(new { success = true, data = result });
        }
    }
}
