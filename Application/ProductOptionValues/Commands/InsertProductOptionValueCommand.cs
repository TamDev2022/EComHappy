using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductOptionValues.Commands
{
    public class InsertProductOptionValueCommand : IRequest<bool>
    {
        public List<OptionValueModel> ListOptionValue { get; set; }

    }

    public class OptionValueModel
    {
        public string ValueName { get; set; }
        public Guid ProductOptionId { get; set; }
    }

    public class InsertProductOptionValueCommandHandler : IRequestHandler<InsertProductOptionValueCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IProductOptionValueRepository _productOptionValueRepository;

        public InsertProductOptionValueCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork,
            IProductOptionValueRepository productOptionValueRepository)
        {
            _unitOfWork = unitOfWork;
            _productOptionValueRepository = productOptionValueRepository;
        }

        public async Task<bool> Handle(InsertProductOptionValueCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var productOptionValues = new List<ProductOptionValue>();
                foreach (var item in request.ListOptionValue)
                {
                    ProductOptionValue option = new()
                    {
                        ValueName = item.ValueName,
                        ProductOptionId = item.ProductOptionId
                    };

                    productOptionValues.Add(option);
                }

                _productOptionValueRepository.Insert(productOptionValues);


                int save = await _unitOfWork.SaveChangesAsync(cancellationToken);
                if (save <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
