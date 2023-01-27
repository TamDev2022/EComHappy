using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductOptionValueRepository : GenericRepository<ProductOptionValue>, IProductOptionValueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductOptionValueRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
