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


    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, bool>
    {

        public GetUserQueryHandler()
        {

        }
        public async Task<bool> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
