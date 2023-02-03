using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductOptionRepository : GenericRepository<ProductOption>, IProductOptionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductOptionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
