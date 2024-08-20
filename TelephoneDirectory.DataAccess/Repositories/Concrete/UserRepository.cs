using TelephoneDirectory.DataAccess.DbContexts;
using TelephoneDirectory.DataAccess.Entities;

using TelephoneDirectory.DataAccess.Repositories.Abstract;


namespace TelephoneDirectory.DataAccess.Repositories.Concrete
{
    public class UserRepository : Repository<User, TelephoneDirectoryDbContext>, IUserRepository
    {
        public UserRepository(TelephoneDirectoryDbContext context) : base(context)
        {
        }
    }
}
