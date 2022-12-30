
using Domain.Share.Base;

namespace Domain.Share.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class, IAggregateRoot;

        Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
        Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string lockName = null, CancellationToken cancellationToken = default);

        void CommitTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        void RollbackTransaction();
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        void SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
