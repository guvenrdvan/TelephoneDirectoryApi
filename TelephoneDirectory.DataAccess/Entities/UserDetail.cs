using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.DataAccess.Entities
{
    public class UserDetail : BaseEntity
    {
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public  int  UserId { get; set; }
        public User User { get; set; }
    }
}
