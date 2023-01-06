using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : BaseEntity<Guid>, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public float Salary { get; set; }

        //public ICollection<Order> Orders { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }

    }
}
