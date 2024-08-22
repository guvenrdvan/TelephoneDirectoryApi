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

        public async Task<BaseResponseModel<List<GetAllUserDetailResponseModel>>> GetAllUserDetail()
        {
            var userIdClaim = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return ResponseManager.Unauthorized<List<GetAllUserDetailResponseModel>>("Kullanıcı bilgileri alınamadı.");
            }

            var userDetail = await _unitOfWork.Repository<IUserDetailRepository>()
                .Query()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            if (userDetail == null || !userDetail.Any())
            {
                return ResponseManager.BadRequest<List<GetAllUserDetailResponseModel>>("Kullanıcı detayı bulunamadı!");
            }

            var responseModel = userDetail.Select(x => new GetAllUserDetailResponseModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).ToList();

            return ResponseManager.Ok(responseModel);
        }

        public async Task<BaseResponseModel<DeleteUserDetailResponseModel>> DeleteUserDetail(DeleteUserDetailRequestModel request)
        {

            var userDetail = await _unitOfWork.Repository<IUserDetailRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (userDetail is not null)
            {
                _unitOfWork.OpenTransaction();
                _unitOfWork.Repository<IUserDetailRepository>().Delete(userDetail);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();

                var responseModel = new DeleteUserDetailResponseModel
                {
                    Id = userDetail.Id,
                    FirstName = userDetail.FirstName,
                    LastName = userDetail.LastName,
                    PhoneNumber = userDetail.PhoneNumber,
                    Email = userDetail.Email,
                };
                return ResponseManager.Ok(responseModel, " İşlem başarılı, Silinen Kişinin bilgileri");
            }

            else
            {
                return ResponseManager.BadRequest<DeleteUserDetailResponseModel>("Böyle bir kişi yok.");
            }
        }

        public async Task<BaseResponseModel> UpdateUserDetail(UpdateUserDetailRequestModel request)
        {
            var userDetail = await _unitOfWork.Repository<IUserDetailRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (userDetail is not null)
            {
                _unitOfWork.OpenTransaction();
                userDetail.FirstName = request.FirstName;
                userDetail.LastName = request.LastName;
                userDetail.PhoneNumber = request.PhoneNumber;
                userDetail.Email = request.Email;
                _unitOfWork.Repository<IUserDetailRepository>().Update(userDetail);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return ResponseManager.Ok("Kişi başarıyla güncellenmiştir");
            }
            else
            {
                return ResponseManager.BadRequest("Kişi bilgisi güncellenirken bir hata oluştu!");
            }

        }

        public async Task<BaseResponseModel<GetUserDetailByIdResponseModel>> GetUserDetailById(int id)
        {
            var userDetail = await _unitOfWork.Repository<IUserDetailRepository>()
                .Query()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (userDetail is not null)
            {
                var response = new GetUserDetailByIdResponseModel
                {
                    Id = userDetail.Id,
                    FirstName = userDetail.FirstName,
                    LastName = userDetail.LastName,
                    PhoneNumber = userDetail.PhoneNumber,
                    Email = userDetail.Email,
                };
                return ResponseManager.Ok(response);
            }
            else
            {
                return ResponseManager.BadRequest<GetUserDetailByIdResponseModel>("Kullanıcı  bulunamadı.");
            }
        }
    }
}

