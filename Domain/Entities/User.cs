
namespace Domain.Entities
{
    public class User : BaseEntity<Guid>, IAggregateRoot
    {

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }

        public string VerifyCode { get; set; }

        public Token Token { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        //public Employee Employee { get; set; }

        public Cart Cart { get; set; }

        public IList<UserStatusTrans> UserStatusTrans { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
