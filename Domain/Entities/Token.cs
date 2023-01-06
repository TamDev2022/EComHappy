using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token : BaseEntity<Guid>, IAggregateRoot
    {

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime StartTimeAccessToken { get; set; }

        public DateTime StartTimeRefreshToken { get; set; }

        public DateTime EndTimeAccessToken { get; set; }

        public DateTime EndTimeRefreshToken { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
