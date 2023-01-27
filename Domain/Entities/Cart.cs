using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart : BaseEntity<Guid>, IAggregateRoot
    {

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IList<CartItem> CartItems { get; set; }
    }
}
