using System.Data;
using TelephoneDirectory.Core.ResponseManager;
using TelephoneDirectory.DataAccess.Repositories.Abstract;

namespace TelephoneDirectory.DataAccess.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void OpenTransaction();
        void OpenTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
        int SaveChanges();
        Task<BaseResponseModel<int>> SaveChangesAsync();
        TRepo Repository<TRepo>() where TRepo : IBaseRepository;
    }
}
