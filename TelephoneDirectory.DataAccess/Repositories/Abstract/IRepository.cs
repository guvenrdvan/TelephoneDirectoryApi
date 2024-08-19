using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.DataAccess.Entities;

namespace TelephoneDirectory.DataAccess.Repositories.Abstract
{
    public interface IRepository<TEntity>  : IBaseRepository where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        List<TEntity> Delete(List<TEntity> entities);
        IQueryable<TEntity> Query();
    }
}
