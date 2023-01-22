﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs.UserModel
{
    public class UserTokenModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}