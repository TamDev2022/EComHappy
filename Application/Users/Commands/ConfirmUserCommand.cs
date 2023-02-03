using Contracts.Enums;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class ConfirmUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string VerifyCode { get; set; }
    }

    public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IUserRepository _userRepository;
        public ConfirmUserCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
        {

            User user = await _userRepository.FindAsync(request.UserId);

            if (request.VerifyCode == user.VerifyCode)
            {
                user.StatusId = (int)StatusEnum.Active;
                var save = await _unitOfWork.SaveChangesAsync();

                if (save > 0) return true;

                return false;
            }

            return false;
        }
    }
}
