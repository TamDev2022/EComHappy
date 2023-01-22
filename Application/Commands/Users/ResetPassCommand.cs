using Application.Common;
using Contracts.Contains;
using Contracts.DTOs.UserModel;
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
    public class ResetPassCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPassCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly SecurityHelper _securityHelper;
        public ResetPasswordCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IUserRepository userRepository,
                                        SecurityHelper securityHelper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _securityHelper = securityHelper;
        }

        public async Task<bool> Handle(ResetPassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userRepository.FindByEmailAsync(request.Email);
                if (result != null)
                {
                    result.Password = _securityHelper.Encode(request.NewPassword);
                    var save = await _unitOfWork.SaveChangesAsync(cancellationToken);
                    if (save > 0) return true;
                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
