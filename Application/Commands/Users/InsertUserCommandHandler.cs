using Application.Common;
using Contracts.Constants;
using Contracts.Enums;
using Contracts.Services;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public InsertUserCommandHandler(IUserRepository userRepository, IUnitOfWork<ApplicationDbContext> unitOfWork,
                                        SecurityHelper securityHelper, IFileStorageManager azureStorage)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _securityHelper = securityHelper;
            _azureStorage = azureStorage;
        }

        public async Task<bool> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var res = await _azureStorage.UploadAsync(request.Avatar);

                if (res.Error)
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
                    RoleId = (int)UserRole.User,
                    StatusId = (int)Status.Unconfirmed,
                    Avatar = res.BlobFile.Uri,
                    CreatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                    UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),

                    Token = new Token
                    {
                        AccessToken = "a",
                        RefreshToken = "b",
                        StartTimeAccessToken = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                        StartTimeRefreshToken = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                        EndTimeAccessToken = DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmssffff"),
                        EndTimeRefreshToken = DateTime.Now.AddMonths(1).ToString("yyyyMMddHHmmssffff"),
                        CreatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                        UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                    }
                };

                //_userRepository.Insert(user);
                //int save = await _unitOfWork.SaveChangesAsync(cancellationToken);

                //if (save < 0)
                //{
                //    await _azureStorage.DeleteAsync(res.BlobFile.Name);
                //    return false;
                //};

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
