using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TokenRepository : GenericRepository<Token>, ITokenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TokenRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Token> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Token?> FindUserIdAsync(int userId)
        {
            return await _dbContext.Token.Where(t => t.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
