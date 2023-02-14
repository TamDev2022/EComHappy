using Application.Common;
using Application.Users.DTOs;
using Domain.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserDTORes?>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }


    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTORes?>
    {
        private readonly IUserRepository _userRepository;

        private readonly SecurityHelper _securityHelper;
        private readonly IJwtTokenService _jwtTokenService;
        public GetUserQueryHandler(IUserRepository userRepository, SecurityHelper securityHelper, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _securityHelper = securityHelper;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<UserDTORes?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userRepository.GetFirstOrDefaultAsync(request.Email);

                if (result != null && _securityHelper.Verify(request.Password, result.Password))
                {
                    return new UserDTORes
                    {
                        Id = result.Id,
                        UserName = result.UserName,
                        Email = result.Email,
                        Role = result.Role.RoleName,
                        Avatar = result.Avatar,
                    };

                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }


        }
    }
}
