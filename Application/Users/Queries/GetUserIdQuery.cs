using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserIdQuery : IRequest<bool>
    {
        public Guid Id { get; set; }

        public GetUserIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
