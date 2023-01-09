using Application.Common;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly SecurityHelper _securityHelper;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork<ApplicationDbContext> unitOfWork, SecurityHelper securityHelper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _securityHelper = securityHelper;
        }


        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = _securityHelper.Encode(request.Password),
                PhoneNumber = request.PhoneNumber,
                VerifyCode = "test",
                Avatar = request.Avatar,
                RoleId = request.RoleId,
            };
            _userRepository.Insert(user);
            var save = await _unitOfWork.SaveChangesAsync();

            if (save < 0) return false;
            return true;

        }
    }
}
