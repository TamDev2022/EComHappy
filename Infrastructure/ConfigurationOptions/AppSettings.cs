using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfigurationOptions
{
    public class AppSettings
    {
        public IdentityAuthentication IdentityAuthentication { get; set; }

        public MailSettings MailSettings { get; set; }

        public StorageSettings Storage { get; set; }

        public JWTSettings JWTSettings { get; set; }
    }
}
