using Microsoft.EntityFrameworkCore;
using TelephoneDirectory.DataAccess.Entities;

namespace TelephoneDirectory.DataAccess.DbContexts
{
    public class TelephoneDirectoryDbContext : DbContext
    {
        public TelephoneDirectoryDbContext(DbContextOptions<TelephoneDirectoryDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UsersDetails { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

