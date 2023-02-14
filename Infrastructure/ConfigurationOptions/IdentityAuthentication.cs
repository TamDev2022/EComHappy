using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfigurationOptions
{
    public class IdentityAuthentication
    {
        public string Authority { get; set; }
        public string IdentityUrl { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public string Prefix { get; set; }
        public float Expires { get; set; }
    }
}
