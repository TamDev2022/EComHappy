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
        public User User { get; set; }

        public Guid EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public IList<OrderItem> OrderItems { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}
