using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity<Guid>, IAggregateRoot
    {

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public Guid OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
