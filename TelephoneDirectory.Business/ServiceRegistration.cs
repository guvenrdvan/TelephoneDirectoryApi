using Microsoft.Extensions.DependencyInjection;
using TelephoneDirectory.Business.Services.Auth.Abstract;
using TelephoneDirectory.Business.Services.Auth.Concrete;
using TelephoneDirectory.Business.Services.UserDetail.Abstract;
using TelephoneDirectory.Business.Services.UserDetailService.Concrete;


namespace TelephoneDirectory.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegistration(this IServiceCollection services)
        {

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserDetailService, UserDetailServices>();
        }
    }
}
