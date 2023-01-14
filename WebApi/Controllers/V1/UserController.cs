using Application.Commands.Users;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int pageIndex = 0, int pageSize = 20)
        {
            var user = await _mediator.Send(new GetUsersQuery(pageIndex, pageSize));

            return new JsonResult(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var res = await _mediator.Send(new GetUserIdQuery(id));

            return new JsonResult(new { success = true });
        }


    }
}
