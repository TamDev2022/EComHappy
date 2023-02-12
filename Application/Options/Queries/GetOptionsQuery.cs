using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Options.Queries
{
    public class GetOptionsQuery : IRequest<IList<Option>>
    {
        //public int Id { get; set; }
    }

    public class GetOptionsQueryHandler : IRequestHandler<GetOptionsQuery, IList<Option>>
    {
        private readonly IOptionRepository _productOptionRepository;
        public GetOptionsQueryHandler(IOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public async Task<IList<Option>> Handle(GetOptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productOptionRepository.GetAllAsync();

            return result;
        }
    }
}
