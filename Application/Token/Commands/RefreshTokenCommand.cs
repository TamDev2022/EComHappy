using Azure.Core;
using Contracts.DTOs.TokenModel;
using Contracts.Enums;
using Contracts.Services;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Token.Commands
{
    public class RefreshTokenCommand : IRequest<TokenDto>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenDto>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public RefreshTokenCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, ITokenRepository tokenRepository,
                                        IJwtTokenService jwtTokenService, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _tokenRepository = tokenRepository;
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }
        public async Task<TokenDto?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {

            var principal = _jwtTokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            if (principal == null) return null;

            var email = principal.Identity.Name;
            if (email == null) return null;

            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null) return null;
            Console.WriteLine("User: " + user);

            var token = await _tokenRepository.FindUserIdAsync(user.Id);
            Console.WriteLine("TOKEN : " + token.Id);

            if (token == null || token.RefreshToken != request.RefreshToken ||
                Convert.ToDouble(token.EndTimeRefreshToken) < Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmssffff")))
            {
                return null;
            }
            token.AccessToken = _jwtTokenService.GenerateAccessToken(email, Enum.GetName(RoleEnum.User));
            _unitOfWork.SaveChanges();

            return new TokenDto
            {
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken
            };
        }
    }
}
