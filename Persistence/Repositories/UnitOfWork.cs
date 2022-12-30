

namespace Persistence.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;
        private IDbContextTransaction _objTran;

        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public TContext DbContext => _dbContext;

        public IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class, IAggregateRoot
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            // what's the best way to support custom reposity?
            if (hasCustomRepository)
            {
                var customRepo = _dbContext.GetService<IGenericRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity>(_dbContext);
            }

            return (IGenericRepository<TEntity>)repositories[type];
        }

        public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            _objTran = await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return _objTran;
        }

        public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string lockName = null, CancellationToken cancellationToken = default)
        {
            _objTran = await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken);

            //var sqlLock = new SqlDistributedLock(_objTran.GetDbTransaction() as SqlTransaction);
            //var lockScope = sqlLock.Acquire(lockName);
            //if (lockScope == null)
            //{
            //    throw new Exception($"Could not acquire lock: {lockName}");
            //}

            return _objTran;
        }

        public void CommitTransaction()
        {
            _objTran.Commit();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _objTran.CommitAsync(cancellationToken);
        }

        public void RollbackTransaction()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _objTran.RollbackAsync(cancellationToken);
            await _objTran.DisposeAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

    }
}
