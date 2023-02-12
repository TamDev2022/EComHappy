using AutoMapper;
using Application.Products.DTOs;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync();
            if (result.Count == 0) throw new ArgumentException("Not found");

            return _mapper.Map<IList<Product>, List<ProductDto>>(result);
        }
    }
}
