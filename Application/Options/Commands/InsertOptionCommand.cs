using Application.Common;
using Application.Options.DTOs;
using AutoMapper;
using Contracts.Services;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Options.Commands
{

    public class InsertOptionCommand : IRequest<OptionDto>
    {
        public string OptionName { get; set; }
        //public List<string> OptionValues { get; set; }
    }

    public class InsertOptionCommandHandler : IRequestHandler<InsertOptionCommand, OptionDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IOptionRepository _productOptionRepository;

        public InsertOptionCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork,
            IOptionRepository productOptionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productOptionRepository = productOptionRepository;
        }

        public async Task<OptionDto> Handle(InsertOptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<OptionValue> optionValue = new List<OptionValue>();

                //foreach (string value in request.OptionValues)
                //{
                //    optionValue.Add(new ProductOptionValue { ValueName = value });
                //}

                var productOption = new Option
                {
                    OptionName = request.OptionName,
                    //ProductOptionValues = optionValue
                };

                var result = _productOptionRepository.Insert(productOption);


                int save = await _unitOfWork.SaveChangesAsync(cancellationToken);
                if (save < 1) throw new ArgumentException("Insert failed");

                return _mapper.Map<OptionDto>(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
