using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface ITrackable
    {
        public byte[] RowVersion { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public DateTimeOffset? UpdatedDateTime { get; set; }
    }
}
