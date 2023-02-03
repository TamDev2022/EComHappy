using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserIdQuery : IRequest<bool>
    {
        public int Id { get; set; }

        public GetUserIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
