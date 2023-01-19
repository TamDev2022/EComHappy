using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        public Task<Token> GetAsync(Guid Id);
        public Task<Token?> FindUserIdAsync(Guid UserId);
    }
}
