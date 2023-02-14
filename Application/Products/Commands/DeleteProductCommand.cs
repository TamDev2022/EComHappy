using Application.Products.DTOs;
using AutoMapper;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.Delete(request.Id);

            int save = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (save < 1) return false;
            return true;

        }
    }
}
