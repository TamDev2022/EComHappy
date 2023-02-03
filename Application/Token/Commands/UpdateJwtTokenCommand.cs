using Contracts.DTOs.TokenModel;
using Contracts.Enums;
using Contracts.Services;
using Domain.Entities;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Token.Commands
{
    public class UpdateJwtTokenCommand : IRequest<TokenDto>
    {
        public int UserId { get; set; }
        public string Email { get; set; }

    }

    public class UpdateJwtTokenCommandHandler : IRequestHandler<UpdateJwtTokenCommand, TokenDto>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ITokenRepository _tokenRepository;
        private readonly IJwtTokenService _jwtTokenService;
        public UpdateJwtTokenCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, ITokenRepository tokenRepository,
                                        IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenRepository = tokenRepository;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<TokenDto?> Handle(UpdateJwtTokenCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.Token result = await _tokenRepository.FindUserIdAsync(request.UserId);

            if (result != null)
            {
                bool check = Convert.ToDouble(result.EndTimeRefreshToken) < Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmssffff")) ? false : true;
                if (!check)
                {
                    result.AccessToken = _jwtTokenService.GenerateAccessToken(request.Email, Enum.GetName(RoleEnum.User));
                    result.RefreshToken = _jwtTokenService.GenerateRefreshToken();
                    result.EndTimeRefreshToken = DateTime.Now.AddMonths(1).ToString("yyyyMMddHHmmssffff");
                    result.UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                }

                result.AccessToken = _jwtTokenService.GenerateAccessToken(request.Email, Enum.GetName(RoleEnum.User));
                result.UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                await _unitOfWork.SaveChangesAsync();
                return new TokenDto { AccessToken = result.AccessToken, RefreshToken = result.RefreshToken };

            }
            return null;

        }
    }
}
