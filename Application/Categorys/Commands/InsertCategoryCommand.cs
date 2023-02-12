using AutoMapper;
using Application.Categorys.DTOs;
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
    public class InsertCategoryCommand : IRequest<CategoryDto>
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var cate = new Category
            {
                CategoryName = request.CategoryName,
                ParentCategoryId = request.ParentCategoryId == null ? null : request.ParentCategoryId,
                CreatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                UpdatedDateTime = DateTime.Now.ToString("yyyyMMddHHmmssffff")
            };

            var result = _categoryRepository.Insert(cate);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(result);
        }
    }
}
