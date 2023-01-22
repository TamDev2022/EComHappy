using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ConfigurationOptions
{
    public class JWTSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string SecretKey { get; set; }
        public string? Prefix { get; set; }
        public int Expires { get; set; }
    }
}
