using TelephoneDirectory.Business.Services.Auth.Models.Request;
using TelephoneDirectory.Business.Services.Auth.Models.Response;
using TelephoneDirectory.Core.ResponseManager;

namespace TelephoneDirectory.Business.Services.Auth.Abstract
{
    public interface IAuthService
    {
        Task<BaseResponseModel<GetUserByIdResponseModel>> GetUserById(int userId);

        Task<BaseResponseModel<LoginUserResponseModel>> Login(LoginUserRequestModel requestModel);

        Task<BaseResponseModel> RegistrationUser(RegisterationUserRequestModel requestModel);
    }
}
