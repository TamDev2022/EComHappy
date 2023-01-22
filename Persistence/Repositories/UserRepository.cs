using Contracts.DTOs.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            var user = await _dbContext.User.Where(u => u.Email == email)
                                      .Include(u => u.Token)
                                      .Include(u => u.Role)
                                      .FirstOrDefaultAsync();
            return user != null ? user : null;
        }

        public async Task<User?> GetAsync(Guid id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null) return user;
            return null;
        }

        public async Task<User> GetFirstOrDefaultAsync(string email)
        {
            var user = await _dbContext.User.Where(u => u.Email == email)
                                      .Include(u => u.Token)
                                      .Include(u => u.Role)
                                      .FirstOrDefaultAsync();
            return user;

        }
    }
}
