using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
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
