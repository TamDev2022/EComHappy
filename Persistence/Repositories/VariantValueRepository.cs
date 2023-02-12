using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VariantValueRepository : GenericRepository<VariantValue>, IVariantValueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VariantValueRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
