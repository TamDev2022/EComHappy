using Application.Token.Commands;
using Application.Users.Commands;
using Application.Users.Queries;
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

        [Route("Sign-In")]
        [HttpPost]
        public async Task<IActionResult> GetAsync([FromBody] GetUserQuery getUserQuery)
        {
            var res1 = await _mediator.Send(getUserQuery);
            if (res1 == null) { return new JsonResult(new { success = false }); }
            var res2 = await _mediator.Send(new UpdateJwtTokenCommand { UserId = res1.Id, Email = res1.Email });
            if (res2 != null)
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

        [Route("Sign-Up")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] InsertUserCommand insertUserCommand)
        {
            var res = await _mediator.Send(insertUserCommand);

            return new JsonResult(new { success = res });
        }

        [Route("Confirm-Email")]
        [HttpPut]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmUserCommand confirmUserCommand)
        {

            var res = await _mediator.Send(confirmUserCommand);

            return new JsonResult(new { success = res });
        }

        [Route("Reset-Password")]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPassCommand resetPassCommand)
        {
            var result = await _mediator.Send(resetPassCommand);

            return new JsonResult(new { success = result });
        }

        [Route("Refresh-Token")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromForm] RefreshTokenCommand refreshTokenCommand)
        {
            var result = await _mediator.Send(refreshTokenCommand);
            return new JsonResult(new { success = result == null ? false : true, data = result });
        }

    }
}
