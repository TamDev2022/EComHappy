using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OptionValues.Queries
{
    public class GetOptionValuesQuery : IRequest<IList<OptionValue>>
    {
        //public int Id { get; set; }
    }

    public class GetOptionValuesQueryHandler : IRequestHandler<GetOptionValuesQuery, IList<OptionValue>>
    {
        private readonly IOptionValueRepository _productOptionValueRepository;
        public GetOptionValuesQueryHandler(IOptionValueRepository productOptionValueRepository)
        {
            _productOptionValueRepository = productOptionValueRepository;
        }

        public async Task<IList<OptionValue>> Handle(GetOptionValuesQuery request, CancellationToken cancellationToken)
        {
            var result = await _productOptionValueRepository.GetAllAsync();

            return result;
        }
    }
}
