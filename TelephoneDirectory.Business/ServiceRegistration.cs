using Microsoft.Extensions.DependencyInjection;
using TelephoneDirectory.Business.Services.Auth.Abstract;
using TelephoneDirectory.Business.Services.Auth.Concrete;

namespace TelephoneDirectory.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegistration(this IServiceCollection services)
        {

            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
