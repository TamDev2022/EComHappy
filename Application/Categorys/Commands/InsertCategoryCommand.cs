using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.Commands
{
    public class InsertCategoryCommand : IRequest<bool>
    {
        public string CategoryName { get; set; }
        public string? ParentCategoryId { get; set; }
    }
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public InsertCategoryCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var cate = new Category
            {
                CategoryName = request.CategoryName,
                ParentCategoryId = request.ParentCategoryId.IsNullOrEmpty() ? null : Convert.ToInt32(request.ParentCategoryId)
            };

            var result = _categoryRepository.Insert(cate);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
