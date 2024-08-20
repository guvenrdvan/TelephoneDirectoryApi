using TelephoneDirectory.Business.Services.UserDetailService.Models.Request;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Response;
using TelephoneDirectory.Core.ResponseManager;

namespace TelephoneDirectory.Business.Services.UserDetail.Abstract
{
    public interface IUserDetailService
    {
        Task<BaseResponseModel<List<GetAllUserDetailResponseModel>>> GetAllUserDetailById(int UserId);
        Task<BaseResponseModel> AddUserDetail(AddUserDetailRequestModel request);

    }
}
