using Application.Common;
using Contracts.Services;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductOptions
{

    public class InsertProductOptionCommand : IRequest<bool>
    {
        public string OptionName { get; set; }
        public InsertProductOptionCommand()
        {

        }
        public InsertProductOptionCommand(string optionName)
        {
            OptionName = optionName;
        }
    }

    public class InsertProductOptionCommandHandler : IRequestHandler<InsertProductOptionCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IProductOptionRepository _productOptionRepository;

        public InsertProductOptionCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork,
            IProductOptionRepository productOptionRepository)
        {
            _unitOfWork = unitOfWork;
            _productOptionRepository = productOptionRepository;
        }

        public async Task<bool> Handle(InsertProductOptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productOption = new ProductOption
                {
                    OptionName = request.OptionName,
                };

                _productOptionRepository.Insert(productOption);


                int save = await _unitOfWork.SaveChangesAsync(cancellationToken);
                if (save <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
