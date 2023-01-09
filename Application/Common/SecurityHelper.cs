using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class SecurityHelper
    {
        /// <inheritdoc/>
        public string Decode(string value)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public string Encode(string value)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(value, BCrypt.Net.HashType.SHA256);
        }

        /// <inheritdoc/>
        public bool verify(string plaintext, string encodedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(plaintext, encodedPassword, BCrypt.Net.HashType.SHA256);
        }
    }
}
