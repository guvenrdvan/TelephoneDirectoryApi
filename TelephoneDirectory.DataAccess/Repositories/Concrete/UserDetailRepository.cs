using TelephoneDirectory.DataAccess.DbContexts;
using TelephoneDirectory.DataAccess.Entities;
using TelephoneDirectory.DataAccess.Repositories.Abstract;

namespace TelephoneDirectory.DataAccess.Repositories.Concrete
{
    public class UserDetailRepository : Repository<UserDetail, TelephoneDirectoryDbContext>, IUserDetailRepository
    {
        public UserDetailRepository(TelephoneDirectoryDbContext context) : base(context)
        {
        }
    }
}
