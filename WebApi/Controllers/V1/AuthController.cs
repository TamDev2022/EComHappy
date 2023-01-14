using Application.Commands.Users;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> GetAsync([FromBody] GetUserQuery getUserQuery)
        {
            var res = await _mediator.Send(getUserQuery);

            return new JsonResult(new { success = true });
        }

        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertUserCommand insertUserCommand)
        {
            await _mediator.Send(insertUserCommand);

            return new JsonResult(new { success = true });
        }

        [Route("confirm-email")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmailAsync(string code)
        {
            return new JsonResult(new { success = true });
        }

        [Route("reset-password")]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] string newPassWord)
        {
            return new JsonResult(new { success = true });
        }

        [Route("refresh-token")]
        [HttpGet]
        public async Task<IActionResult> RefreshTokenAsync(Guid id, string token)
        {
            return new JsonResult(new { success = true });
        }

    }
}
