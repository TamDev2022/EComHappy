using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductVariantValueRepository : GenericRepository<ProductVariantValue>, IProductVariantValueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductVariantValueRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
