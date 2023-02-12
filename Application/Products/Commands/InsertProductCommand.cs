using Application.Common;
using AutoMapper;
using Application.Products.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace Application.Products.Commands
{
    public class InsertProductCommand : IRequest<ProductDto>
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }

        public IList<ProductVariants> Variants { get; set; }
        public IList<Options> POptions { get; set; }


        public class ProductVariants
        {
            public string Title { get; set; }
            public string Gender { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }

            public IList<OptionWithValues> OptionWithValues { get; set; }

            //public IFormFile? FormFile { get; set; }


        }

        public class Options
        {
            public int OptionId { get; set; }

        }
        public class OptionWithValues
        {
            public int OptionId { get; set; }
            public int OptionValueId { get; set; }

        }

    }


    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IProductOptionRepository _productOptionRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IVariantValueRepository _variantValueRepository;
        private readonly SecurityHelper _securityHelper;


        public InsertProductCommandHandler(IMapper mapper, IUnitOfWork<ApplicationDbContext> unitOfWork, IProductRepository productRepository,
                                            SecurityHelper securityHelper, IProductVariantRepository productVariantRepository,
                                            IProductOptionRepository productOptionRepository, IVariantValueRepository variantValueRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _securityHelper = securityHelper;
            _productVariantRepository = productVariantRepository;
            _productOptionRepository = productOptionRepository;
            _variantValueRepository = variantValueRepository;
        }
        public async Task<ProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var product = new Product()
                {
                    ProductName = request.ProductName,
                    CategoryId = request.CategoryId,
                    BranId = request.BrandId,
                    Description = request.Description
                };

                Console.WriteLine("productRequest:" + request.ProductName);

                List<ProductOption> productOptions = new List<ProductOption>();
                List<ProductVariant> productVariants = new List<ProductVariant>();


                var resultProduct = _productRepository.Insert(product);
                int save = await _unitOfWork.SaveChangesAsync();
                if (save < 1) throw new ArgumentException("Insert failed");

                foreach (var option in request.POptions)
                {
                    ProductOption productOption = new ProductOption
                    {
                        OptionId = option.OptionId,
                        Product = resultProduct
                    };

                    productOptions.Add(productOption);
                }

                await _productOptionRepository.InsertAsync(productOptions, cancellationToken);
                int save1 = await _unitOfWork.SaveChangesAsync();
                if (save1 < 1) throw new ArgumentException("Insert failed");

                foreach (var variant in request.Variants)
                {
                    ProductVariant productVariant = new ProductVariant
                    {
                        Title = variant.Title,
                        Gender = variant.Gender,
                        Price = variant.Price,
                        SKU = _securityHelper.RandomDigit(),
                        Product = resultProduct
                    };

                    List<VariantValue> variantValues = new List<VariantValue>();

                    foreach (var optionvalue in variant.OptionWithValues)
                    {
                        foreach (var option in productOptions)
                        {
                            if (option.OptionId == optionvalue.OptionId)
                            {
                                VariantValue variantValue = new VariantValue
                                {
                                    ProductId = resultProduct.Id,
                                    OptionId = optionvalue.OptionId,
                                    OptionValueId = optionvalue.OptionValueId,
                                    ProductVariant = productVariant,
                                    //ProductOption = option
                                };

                                variantValues.Add(variantValue);
                            }
                        }

                    }

                    productVariant.VariantValues = variantValues;
                    productVariants.Add(productVariant);

                    _productVariantRepository.Insert(productVariant);
                    int save2 = await _unitOfWork.SaveChangesAsync();
                    if (save2 < 1) throw new ArgumentException("Insert failed");
                }

                _unitOfWork.CommitTransaction();

                return _mapper.Map<ProductDto>(resultProduct); ;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

