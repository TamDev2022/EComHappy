using AutoMapper;
using Domain.Repositories;
using Persistence;
using Application.Brands.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Queries
{
    public class GetBrandIdQuery : IRequest<BrandDto>
    {
        public int Id { get; set; }
    }

    public class GetBrandIdQueryHandler : IRequestHandler<GetBrandIdQuery, BrandDto>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        public GetBrandIdQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<BrandDto> Handle(GetBrandIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _brandRepository.FindAsync(request.Id);

            return _mapper.Map<BrandDto>(result);
        }
    }
}
