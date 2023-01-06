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

        public string RoleName { get; set; }

        public ICollection<User> Users;
    }
}
