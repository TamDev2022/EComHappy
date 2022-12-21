using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid RoleId;

        public string RoleName;

        public User User;
    }
}
