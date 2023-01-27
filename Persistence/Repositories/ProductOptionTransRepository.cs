using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductOptionTransRepository : GenericRepository<ProductOptionTrans>, IProductOptionTransRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductOptionTransRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
