using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetUserDetails()
        {
            var response = await _userDetailService.GetAllUserDetailById();
            return HandleResponse(response);
        }


        [HttpPost("Add-User-Detail")]    
        public async Task<IActionResult> AddUserDetail([FromBody] AddUserDetailRequestModel request)
        {
            var response = await _userDetailService.AddUserDetail(request);
            return HandleResponse(response);
        }


        [HttpDelete("Delete-User-Detail")]
        public async Task<IActionResult> DeleteUserDetail([FromBody] DeleteUserDetailRequestModel request)
        {
            var response = await _userDetailService.DeleteUserDetail(request);
            return HandleResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimalType([FromRoute] int id, [FromBody] UpdateUserDetailRequestModel request)
        {
            request.Id = id;
            var result = await _userDetailService.UpdateUserDetail(request);
            return HandleResponse(result);
        }

   /*     [HttpPut("Update-User-Detail")]
        public async Task<IActionResult> UpdateUserDetail([FromBody] UpdateUserDetailRequestModel request)
        {
            var response = await _userDetailService.UpdateUserDetai(request);
            return HandleResponse(response);
        }*/
    }
}
