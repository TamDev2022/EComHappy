using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contains
{
    public class MailContent
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
    }
}
