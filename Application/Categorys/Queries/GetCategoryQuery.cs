using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.Queries
{
    public class GetCategoryQuery : IRequest<IList<Category>>
    {
    }

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IList<Category>>
    {
        public readonly ICategoryRepository _categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IList<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll().ToListAsync();
            if (result == null) throw new ArgumentException($"Không có Category nào ");

            return result;
        }
    }
}
