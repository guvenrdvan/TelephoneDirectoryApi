using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TelephoneDirectory.Business.Services.UserDetail.Abstract;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Request;
using TelephoneDirectory.Business.Services.UserDetailService.Models.Response;
using TelephoneDirectory.Core.ResponseManager;
using TelephoneDirectory.DataAccess.Repositories.Abstract;
using TelephoneDirectory.DataAccess.UnitOfWorks.Abstract;

namespace TelephoneDirectory.Business.Services.UserDetailService.Concrete
{
    public class UserDetailServices : IUserDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;


        public UserDetailServices(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponseModel> AddUserDetail(AddUserDetailRequestModel request)
        {
            var userIdClaim = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return ResponseManager.Unauthorized("Kullanıcı bilgileri alınamadı.");
            }

            var userDetail = new DataAccess.Entities.UserDetail
            {
                FirstName = request.FirstName,
                LastName = request.Lastname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserId = userId
            };
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserDetailRepository>().Add(userDetail);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.Commit();

            return ResponseManager.Ok("Kişi rehbere başarıyla kaydedildi.");
        }

        public async  Task<BaseResponseModel<List<GetAllUserDetailResponseModel>>> GetAllUserDetailById(int UserId)
        {
            var userDetail = await _unitOfWork.Repository<IUserDetailRepository>()
                .Query()
                .Where(x => x.UserId == UserId)
                .ToListAsync();
                
            if(userDetail is null || userDetail.Any())
            {
                return ResponseManager.BadRequest<List<GetAllUserDetailResponseModel>>("Kullanıcı detayı bulunamadı!");
            }

            var responseModel = userDetail.Select(x => new GetAllUserDetailResponseModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).ToList();
            return ResponseManager.Ok(responseModel);

        }
    }
}
