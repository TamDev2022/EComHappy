using Application.Common;
using Application.Service;
using Domain.Infrastructure.Storages;
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
            var res = await _azureStorage.UploadAsync(request.Avatar);
            if (!res.Error)
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
                RoleId = 1,
                StatusId = 1,
                Avatar = res.BlobFile.Uri,

                //Token = new Token
                //{
                //    AccessToken = "a",
                //    StartTimeAccessToken = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                //    StartTimeRefreshToken = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                //    EndTimeAccessToken = DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmssffff"),
                //    EndTimeRefreshToken = DateTime.Now.AddMonths(1).ToString("yyyyMMddHHmmssffff"),
                //}
            };

            _userRepository.Insert(user);
            var save = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (save < 0)
            {
                await _azureStorage.DeleteAsync(res.BlobFile.Name);
                return false;
            };
            return true;

        }
    }
}
