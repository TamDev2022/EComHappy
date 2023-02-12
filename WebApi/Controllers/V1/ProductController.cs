using Application.Products.Commands;
using Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] InsertProductCommand insertProductCommand)
        {
            var result = await _mediator.Send(insertProductCommand);

            return new JsonResult(new { success = true, data = result });
        }


        //[Authorize]
        [Route("Products")]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _mediator.Send(new GetProductsQuery());

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("ProductId")]
        [HttpGet]
        public async Task<IActionResult> GetProductIdAsync()
        {
            //var result = await _mediator.Send();

            return new JsonResult(new { success = true });
        }
    }

}
