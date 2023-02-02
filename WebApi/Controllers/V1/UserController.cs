using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(int pageIndex = 0, int pageSize = 20)
        {
            var result = await _mediator.Send(new GetUsersQuery(pageIndex, pageSize));

            return new JsonResult(new { success = true, data = result });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetProfileAsync(Guid id)
        {
            var result = await _mediator.Send(new GetUserIdQuery(id));

            return new JsonResult(new { success = true, data = result });
        }


    }
}
