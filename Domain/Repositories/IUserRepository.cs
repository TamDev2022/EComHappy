using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserQueryOptions
    {
        public bool IncludePasswordHistories { get; set; }
        public bool IncludeClaims { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool IncludeRoles { get; set; }
        public bool IncludeTokens { get; set; }
        public bool AsNoTracking { get; set; }
    }

    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetAsync(int Id);
        public Task<User> GetFirstOrDefaultAsync(string email);
        public Task<User?> FindByEmailAsync(string email);
    }
}
