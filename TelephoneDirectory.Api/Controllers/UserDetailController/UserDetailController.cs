using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Business.Services.UserDetail.Abstract;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Request;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Response;
using TelephoneDirectory.Core.ResponseManager;

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


        [HttpGet("Get-AllUser-details")]
        public async Task<IActionResult> GetUserDetails()
        {
            var response = await _userDetailService.GetAllUserDetail();
            return HandleResponse(response);
        }    

        [HttpPost("Add-User-details")]    
        public async Task<IActionResult> AddUserDetail([FromBody] AddUserDetailRequestModel request)
        {
            var response = await _userDetailService.AddUserDetail(request);
            return HandleResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail([FromRoute]  int id)
        {
            var request = new DeleteUserDetailRequestModel { Id = id };
            var response = await _userDetailService.DeleteUserDetail(request);
            return HandleResponse(response);
        }

        [HttpGet("Get-UserById-details")]
        public async Task<IActionResult> GetUserDetailsById(int id)
        {
            var response = await _userDetailService.GetUserDetailById(id);
            return HandleResponse(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetail([FromRoute] int id, [FromBody] UpdateUserDetailRequestModel request)
        {
                
            request.Id = id;
            var response = await _userDetailService.UpdateUserDetail(request);
            return HandleResponse(response);
        }

   
    }
}
