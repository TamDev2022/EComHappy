using Contracts.Contains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IMailService
    {
        public Task SendMailAsync(MailContent mailContent);
        public Task SendMailClickAsync(MailContent mailContent);


    }
}
