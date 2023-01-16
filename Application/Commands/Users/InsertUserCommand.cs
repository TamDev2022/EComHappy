using Application.Common;
using Contracts.Enums;
using Contracts.Services;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class InsertUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }

        public InsertUserCommand()
        {

        }
        public InsertUserCommand(string userName, string email, string password, string phoneNumber, IFormFile avatar)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
        }
    }

}
