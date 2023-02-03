using Application.Categorys.Commands;
using Application.Categorys.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertCategoryCommand insertCategoryCommand)
        {
            var result = await _mediator.Send(insertCategoryCommand);

            return new JsonResult(new { success = true });
        }

        //[Authorize]
        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromForm] InsertCategoryCommand insertCategoryCommand)
        {
            var result = await _mediator.Send(insertCategoryCommand);

            return new JsonResult(new { success = true });
        }

        //[Authorize]
        [Route("Categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _mediator.Send(new GetCategoryQuery());

            return new JsonResult(new { success = true, data = result });
        }

        //[Authorize]
        [Route("CategoryId")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryIdAsync([FromQuery] GetCategoryIdQuery categoryIdQuery)
        {
            var result = await _mediator.Send(categoryIdQuery);

            return new JsonResult(new { success = true, data = result });
        }
    }
}
