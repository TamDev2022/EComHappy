using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserStatus
{
    public class CreateStatus : IRequest<bool>
    {
        [DataMember]
        public string StatusName { get; set; }

        public CreateStatus(string statusName)
        {
            StatusName = statusName;
        }
    }
}
