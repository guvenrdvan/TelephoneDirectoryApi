using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Business.Services.UserDetailService.Models.Request
{
    public class AddUserDetailRequestModel
    {
        [Required]
        [Length(2, 30)]
        public string FirstName { get; set; }

        [Required]
        [Length(2, 30)]
        public string Lastname { get; set; }

        [Required]    
        public string Email { get; set; }

        [Required]
        [Length(11, 12)]
        public string PhoneNumber { get; set; }
    }
}
