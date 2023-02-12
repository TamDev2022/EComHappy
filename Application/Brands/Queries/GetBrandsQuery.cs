using AutoMapper;
using Application.Brands.DTOs;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Queries
{
    public class GetBrandsQuery : IRequest<List<BrandDto>>
    {
    }

    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<BrandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        public GetBrandsQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<List<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var result = await _brandRepository.GetAllAsync();

            return _mapper.Map<IList<Brand>, List<BrandDto>>(result);
        }
    }
}
