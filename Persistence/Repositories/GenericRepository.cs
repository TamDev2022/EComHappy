using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IAggregateRoot
    {
        private readonly ApplicationDbContext _dbContext;
        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ToListAsync<T>(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
