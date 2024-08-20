using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Business.Services.Auth.Abstract;
using TelephoneDirectory.Business.Services.Auth.Models.Request;


namespace TelephoneDirectory.Api.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public UserController(IAuthService authService, IConfiguration configuration )
        {
            _authService = authService;
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterationUserRequestModel request)
        {
            var result = await _authService.RegistrationUser(request);
            return HandleResponse(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var response = await _authService.Login(request);
            return Ok(response);
        }
    }
}
