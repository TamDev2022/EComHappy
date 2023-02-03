using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
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

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, bool>
    {
        public Task<bool> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
