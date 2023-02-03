using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        public Task<Token> GetAsync(int Id);
        public Task<Token?> FindUserIdAsync(int UserId);
    }
}
