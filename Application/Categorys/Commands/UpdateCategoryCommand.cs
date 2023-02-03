using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
