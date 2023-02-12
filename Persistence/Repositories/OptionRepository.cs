using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OptionRepository : GenericRepository<Option>, IOptionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OptionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
