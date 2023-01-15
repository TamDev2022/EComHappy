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
        public string GenerateAccessToken(User user);

        public string GenerateRefreshToken();

        public RefreshTokenDTO GenerateRefreshToken(int userId);

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
