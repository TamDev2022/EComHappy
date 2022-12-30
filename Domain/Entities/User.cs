using Domain.Share.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        //public IList<UserToken> Tokens { get; set; }

        public Role Role { get; set; }

    }
}
