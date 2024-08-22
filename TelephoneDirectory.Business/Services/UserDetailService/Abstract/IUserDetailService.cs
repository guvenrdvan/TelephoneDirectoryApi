using TelephoneDirectory.Business.Services.UserDetailService.Models.Request;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Response;
using TelephoneDirectory.Core.ResponseManager;

namespace TelephoneDirectory.Business.Services.UserDetail.Abstract
{
    public interface IUserDetailService
    {
        Task<BaseResponseModel<List<GetAllUserDetailResponseModel>>> GetAllUserDetail();
        Task<BaseResponseModel<GetUserDetailByIdResponseModel>> GetUserDetailById(int id);
        Task<BaseResponseModel> AddUserDetail(AddUserDetailRequestModel request);
        Task<BaseResponseModel<DeleteUserDetailResponseModel>> DeleteUserDetail(DeleteUserDetailRequestModel request);
        Task<BaseResponseModel> UpdateUserDetail(UpdateUserDetailRequestModel request);
    }
}
