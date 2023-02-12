using Application.Options.DTOs;
using AutoMapper;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Options.Commands
{
    public class InsertOptionWithValueCommand : IRequest<OptionDto>
    {
        public string OptionName { get; set; }
        public List<string> OptionValues { get; set; }
    }


    public class InsertOptionWithValueCommandHandler : IRequestHandler<InsertOptionWithValueCommand, OptionDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IOptionRepository _productOptionRepository;

        public InsertOptionWithValueCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork,
            IOptionRepository productOptionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productOptionRepository = productOptionRepository;
        }

        public async Task<OptionDto> Handle(InsertOptionWithValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<OptionValue> optionValue = new List<OptionValue>();

                foreach (string value in request.OptionValues)
                {
                    optionValue.Add(new OptionValue { ValueName = value });
                }

                var productOption = new Option
                {
                    OptionName = request.OptionName,
                    OptionValues = optionValue
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
