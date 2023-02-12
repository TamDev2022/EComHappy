using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity<int>, IAggregateRoot
    {

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
