using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.DataAccess.DbContexts;
using TelephoneDirectory.DataAccess.UnitOfWorks.Abstract;
using TelephoneDirectory.DataAccess.UnitOfWorks.Concrete;

namespace TelephoneDirectory.DataAccess
{
    public static class ServiceRegistration
    {
        public static void DataAccessRegistration(this IServiceCollection services)
        {
            var connectionString = ("Data Source=RıDVAN\\SQLEXPRESS;Initial Catalog=Db_TelephoneDirectory;Integrated Security=True;Trust Server Certificate=True");

            services.AddDbContext<TelephoneDirectoryDbContext>(x =>
            {
                x.UseSqlServer(connectionString, opt =>
                {
                    opt.CommandTimeout(120);
                });
                x.EnableSensitiveDataLogging();
            });
            services.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<TelephoneDirectoryDbContext>));
            services.TryAddScoped<DbContext, TelephoneDirectoryDbContext>();
        }
    }
}
