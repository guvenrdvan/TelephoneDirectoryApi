﻿using System.ComponentModel.DataAnnotations;

namespace TelephoneDirectory.DataAccess.Entities
{
    public class UserDetail : BaseEntity
    {
        [MaxLength(30)]
        public  string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public  int  UserId { get; set; }
        public User User { get; set; }
    }
}
