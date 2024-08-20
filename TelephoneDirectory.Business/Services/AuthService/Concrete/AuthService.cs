﻿using Microsoft.EntityFrameworkCore;
using TelephoneDirectory.Business.Services.Auth.Abstract;
using TelephoneDirectory.Business.Services.Auth.Models.Request;
using TelephoneDirectory.Business.Services.Auth.Models.Response;
using TelephoneDirectory.Core.ResponseManager;
using TelephoneDirectory.Core.Utils;
using TelephoneDirectory.DataAccess.Repositories.Abstract;
using TelephoneDirectory.DataAccess.UnitOfWorks.Abstract;

namespace TelephoneDirectory.Business.Services.Auth.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel<GetUserByIdResponseModel>> GetUserById(int userId)
        {
            var user = await _unitOfWork.Repository<IUserRepository>().Query().FirstOrDefaultAsync(x => x.Id == userId);
            return ResponseManager.Ok(new GetUserByIdResponseModel
            {
                FirstName = user.FİrstName,
                LastName = user.LastName,
            });
        }

        public async Task<BaseResponseModel<LoginUserResponseModel>> Login(LoginUserRequestModel requestModel)
        {
            var ifUserExist = await _unitOfWork.Repository<IUserRepository>()
                .Query()
                .FirstOrDefaultAsync(x => x.UserName == requestModel.userName);

            if (ifUserExist is not null)
            {
                var isVerifed = PasswordManager.VerifyPassword(requestModel.password, ifUserExist.PasswordHash, Convert.FromBase64String(ifUserExist.PasswordSalt));
                if (!isVerifed)
                {
                    return ResponseManager.BadRequest<LoginUserResponseModel>("Şifte Yanlış");
                }
                else
                {
                    return ResponseManager.Ok(new LoginUserResponseModel
                    {
                        Id = ifUserExist.Id,
                    });
                }
            }
            else
            {
                return ResponseManager.BadRequest<LoginUserResponseModel>("Kullanıcı bulunamadı.");
            }
        }

        public async Task<BaseResponseModel> RegistrationUser(RegisterationUserRequestModel requestModel)
        {
            var ifUserExist = await _unitOfWork.Repository<IUserRepository>()
                .Query()
                .FirstOrDefaultAsync(x => x.UserName == requestModel.UserName);

            if (ifUserExist is not null)
            {
                return ResponseManager.BadRequest("Bu kullanıcı adına sahip kullanıcı var!");
            }

            var passwordSalt = PasswordManager.GenerateSalt();
            var passwordHash = PasswordManager.HashPassword(requestModel.Password, passwordSalt);

            var user = new DataAccess.Entities.User
            {
                UserName = requestModel.UserName,
                FİrstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = Convert.ToBase64String(passwordSalt),
            };
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRepository>().Add(user);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.Commit();

            return ResponseManager.Ok();
        }
    }
}
