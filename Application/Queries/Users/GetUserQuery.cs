using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public class GetUserQuery : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public GetUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class GetUserIdQuery : IRequest<bool>
    {
        public Guid Id { get; set; }

        public GetUserIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

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
