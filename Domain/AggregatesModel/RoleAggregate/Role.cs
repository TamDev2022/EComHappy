
using Domain.Share.Base;

namespace Domain.AggregatesModel.RoleAggregate
{
    public class Role : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid RoleId;

        public string RoleName;

        public User User;
    }
}
