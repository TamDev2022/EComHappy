using AutoMapper;
using Application.Brands.DTOs;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Commands
{
    public class InsertBrandCommand : IRequest<BrandDto>
    {
        public string BrandName { get; set; }
    }

    public class InsertBrandCommandHandler : IRequestHandler<InsertBrandCommand, BrandDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IBrandRepository _brandRepository;
        public InsertBrandCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto> Handle(InsertBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new Brand() { BrandName = request.BrandName };
            var result = _brandRepository.Insert(brand);

            int save = await _unitOfWork.SaveChangesAsync();

            if (save < 1) throw new ArgumentException("Insert fail");

            return _mapper.Map<BrandDto>(result);
        }
    }

}
