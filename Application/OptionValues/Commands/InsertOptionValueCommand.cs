using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OptionValues.Commands
{
    public class InsertOptionValueCommand : IRequest<bool>
    {
        public List<OptionValueModel> ListOptionValue { get; set; }
        public int ProductOptionId { get; set; }

    }

    public class OptionValueModel
    {
        public string ValueName { get; set; }
    }

    public class InsertOptionValueCommandHandler : IRequestHandler<InsertOptionValueCommand, bool>
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IOptionValueRepository _productOptionValueRepository;

        public InsertOptionValueCommandHandler(IUnitOfWork<ApplicationDbContext> unitOfWork,
            IOptionValueRepository productOptionValueRepository)
        {
            _unitOfWork = unitOfWork;
            _productOptionValueRepository = productOptionValueRepository;
        }

        public async Task<bool> Handle(InsertOptionValueCommand request, CancellationToken cancellationToken)
        {
            try
            {

                List<OptionValue> productOptionValues = new List<OptionValue>();
                foreach (var item in request.ListOptionValue)
                {
                    OptionValue option = new()
                    {
                        ValueName = item.ValueName,
                        OptionId = request.ProductOptionId
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
