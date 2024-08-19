using TelephoneDirectory.Business.Services.Auth.Abstract;
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
    }
}
