using Domain.Repositories;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetCategoryIdQueryHandler> _logger;
        public GetCategoryIdQueryHandler(ICategoryRepository categoryRepository, ILogger<GetCategoryIdQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Category> Handle(GetCategoryIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request: " + request.Id);
            var result = await _categoryRepository.FindAsync(request.Id);
            if (result == null) throw new ArgumentException("Không có Category nào ");

            return result;
        }
    }
}
