using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface ITrackable
    {
        public string? CreatedDateTime { get; set; }

        public string? UpdatedDateTime { get; set; }
    }
}
