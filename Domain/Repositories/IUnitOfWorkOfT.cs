namespace Domain.Repositories
{
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}
