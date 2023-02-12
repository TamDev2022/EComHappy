using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OptionValueRepository : GenericRepository<OptionValue>, IOptionValueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OptionValueRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
