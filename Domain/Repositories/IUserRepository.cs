
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
        IQueryable<User> Get(UserQueryOptions queryOptions);
    }
}
