using Application.Commands.Token;
using Application.Commands.Users;
using Application.Queries.Users;
using Contracts.DTOs.UserModel;
using Domain.Entities;
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
            var res1 = await _mediator.Send(getUserQuery);
            var res2 = await _mediator.Send(new UpdateJwtTokenCommand { UserId = res1.Id, Email = res1.Email }); ;
            if ((res1 != null && res2 != null))
            {
                UserTokenModel data = new()
                {
                    Id = res1.Id,
                    UserName = res1.UserName,
                    Role = res1.Role,
                    Avatar = res1.Avatar,
                    AccessToken = res2.AccessToken,
                    RefreshToken = res2.RefreshToken,
                };
                return new JsonResult(new { success = true, data });
            }
            return new JsonResult(new { success = false });

        }

        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertUserCommand insertUserCommand)
        {
            var res = await _mediator.Send(insertUserCommand);

            return new JsonResult(new { success = res });
        }

        [Route("confirm-email")]
        [HttpPut]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmUserCommand confirmUserCommand)
        {

            var res = await _mediator.Send(confirmUserCommand);

            return new JsonResult(new { success = res });
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
