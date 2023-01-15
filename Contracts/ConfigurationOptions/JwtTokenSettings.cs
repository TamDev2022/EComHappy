using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ConfigurationOptions
{
    public class JwtTokenSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string SecretKey { get; init; } = "defaultsecretkey";
        public string? Prefix { get; init; }
        public int Expires { get; init; }
    }
}
