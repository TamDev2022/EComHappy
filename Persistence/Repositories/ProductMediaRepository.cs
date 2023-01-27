using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductMediaRepository : GenericRepository<ProductMedia>, IProductMediaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductMediaRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
