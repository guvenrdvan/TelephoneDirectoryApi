using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using TelephoneDirectory.Business.Services.Auth.Abstract;
using TelephoneDirectory.Business.Services.Auth.Models.Request;


namespace TelephoneDirectory.Api.Controllers.UserController
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly  IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }



        [Microsoft.AspNetCore.Mvc.HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationUserRequestModel request)
        {
            var result = await _authService.RegistrationUser(request);
            return HandleResponse(result);
        }

    }
}
