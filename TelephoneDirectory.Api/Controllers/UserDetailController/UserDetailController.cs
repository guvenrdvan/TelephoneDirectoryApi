using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TelephoneDirectory.Business.Services.UserDetail.Abstract;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Request;

namespace TelephoneDirectory.Api.Controllers.UserDetailController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailController : BaseController
    {
        private readonly  IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }

        [HttpGet("get-user-details")]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
          //  var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _userDetailService.GetAllUserDetailById(userId);
            return HandleResponse(response);
        }

        [HttpPost("Add-User-Detail")]

        public async Task<IActionResult> AddUserDetail([FromBody] AddUserDetailRequestModel request)
        {
            var response = await _userDetailService.AddUserDetail(request);
            return HandleResponse(response);
        }
    }
}
