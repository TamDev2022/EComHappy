using Application.Common;
using Contracts.Contains;
using Contracts.Enums;
using Contracts.Services;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly SecurityHelper _securityHelper;
        private readonly IFileStorageManager _azureStorage;
        public readonly IJwtTokenService _jwtTokenService;
        public readonly IMailService _mailService;

        public InsertUserCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IUserRepository userRepository,
                                        SecurityHelper securityHelper, IFileStorageManager azureStorage,
                                        IJwtTokenService jwtTokenService, IMailService mailService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _securityHelper = securityHelper;
            _azureStorage = azureStorage;
            _jwtTokenService = jwtTokenService;
            _mailService = mailService;
        }

        public async Task<bool> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _azureStorage.UploadAsync(request.Avatar);

                if (res == null || res.Error)
                {
                    return false;
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.Email),
                    new Claim(ClaimTypes.Role, Enum.GetName(RoleEnum.User))
                };

                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = _securityHelper.Encode(request.Password),
                    PhoneNumber = request.PhoneNumber,
                    VerifyCode = _securityHelper.RandomDigit(),
                    RoleId = (int)RoleEnum.User,
                    StatusId = (int)StatusEnum.Unconfirmed,
                    Avatar = res.BlobFile.Uri,
                    CreatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                    UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),

                    Token = new Token
                    {
                        AccessToken = _jwtTokenService.GenerateAccessToken(claims),
                        RefreshToken = _jwtTokenService.GenerateRefreshToken(),
                        EndTimeRefreshToken = DateTime.Now.AddMonths(1).ToString("yyyyMMddHHmmssffff"),
                        CreatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                        UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                    }
                };



                _userRepository.Insert(user);

                int save = await _unitOfWork.SaveChangesAsync(cancellationToken);

                MailContent mail = new()
                {
                    To = request.Email,
                    Subject = "Confirm account",
                    Content = user.VerifyCode
                };

                await _sendMailService.SendMailAsync(mail);

                if (save < 0)
                {
                    await _azureStorage.DeleteAsync(res.BlobFile.Name);
                    return false;
                };

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
