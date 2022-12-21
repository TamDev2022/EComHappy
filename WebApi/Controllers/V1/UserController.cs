using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
    }

    //[Route("list")]
    //[HttpGet]
    //public async Task<IActionResult> GetListUserAsync(int PageNumber = 1, int PageSize = 10)
    //{
    //    var data = await _userService.GetListAsync(PageNumber, PageSize).ConfigureAwait(false);
    //    return new JsonResult(new { success = true, data });
    //}

}
