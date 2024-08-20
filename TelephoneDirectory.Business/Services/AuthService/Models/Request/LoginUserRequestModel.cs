using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Business.Services.Auth.Models.Request
{
    public class LoginUserRequestModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
