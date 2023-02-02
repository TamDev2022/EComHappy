using Application.Common;
using Contracts.Contains;
using Contracts.Enums;
using Contracts.Services;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
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

                    Token = new Domain.Entities.Token
                    {
                        AccessToken = _jwtTokenService.GenerateAccessToken(request.Email, Enum.GetName(RoleEnum.User)),
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

                await _mailService.SendMailAsync(mail);

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
