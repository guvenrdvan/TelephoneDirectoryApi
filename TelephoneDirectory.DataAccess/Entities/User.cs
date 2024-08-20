using System.ComponentModel.DataAnnotations;

namespace TelephoneDirectory.DataAccess.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string FİrstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
