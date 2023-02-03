
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : BaseEntity<int>, IAggregateRoot
    {

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        public string VerifyCode { get; set; }

        public virtual Token Token { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int StatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
