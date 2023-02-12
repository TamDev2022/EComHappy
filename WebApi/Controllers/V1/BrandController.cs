using Application.Brands.Commands;
using Application.Brands.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertBrandCommand insertBrandCommand)
        {
            var result = await _mediator.Send(insertBrandCommand);

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("Brands")]
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync()
        {
            var result = await _mediator.Send(new GetBrandsQuery());

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("BrandId")]
        [HttpGet]
        public async Task<IActionResult> GetBrandIdAsync([FromQuery] GetBrandIdQuery getBrandIdQuery)
        {
            var result = await _mediator.Send(getBrandIdQuery);

            return new JsonResult(new { success = true, data = result });
        }
    }
}
