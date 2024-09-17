using System.Data;

namespace AuthShield.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task CommitTransactionAsync();
        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
        Task RollbackTransactionAsync();
        int SaveChanges(bool ensureAutoHistory = false);
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false);



        //Custom Repositoy
        IUserRepository Users { get; }
    }
}
