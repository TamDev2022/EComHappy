using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class GetUsersQuery : IRequest<bool>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public GetUsersQuery(int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }
    }
}
