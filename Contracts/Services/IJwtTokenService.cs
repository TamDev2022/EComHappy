using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IJwtTokenService
    {

        public string GenerateAccessToken(IEnumerable<Claim> claims);

        public string GenerateAccessToken(string name, string role);

        public string GenerateRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
