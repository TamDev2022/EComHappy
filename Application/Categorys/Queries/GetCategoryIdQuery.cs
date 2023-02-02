using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.Queries
{
    public class GetCategoryIdQuery : IRequest<Category>
    {
        public int Id { get; set; }
    }

    public class GetCategoryIdQueryHandler : IRequestHandler<GetCategoryIdQuery, Category>
    {
        public readonly ICategoryRepository _categoryRepository;
        public GetCategoryIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> Handle(GetCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var result = _categoryRepository.Find(request.Id);
            if (result == null) throw new ArgumentException("Không có Category nào ");

            return Task.FromResult(result);
        }
    }
}
