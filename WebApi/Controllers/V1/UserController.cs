using Application.Commands.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
        private readonly Mediator _mediator;
        public UserController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand createUserCommand)
        {
            _mediator.Send(createUserCommand);

            return new JsonResult(new { success = true });
        }
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetListUserAsync(int PageNumber = 1, int PageSize = 10)
        {
            //var data = await _userService.GetListAsync(PageNumber, PageSize).ConfigureAwait(false);

            return new JsonResult(new { success = true });
        }
    }
}
