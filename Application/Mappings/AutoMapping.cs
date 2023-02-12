using AutoMapper;
using Application.Brands.DTOs;
using Application.Categorys.DTOs;
using Application.Products.DTOs;
using Application.Options.DTOs;
using Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserDTORes, User>();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<OptionDto, Option>().ReverseMap();
            CreateMap<BrandDto, Brand>().ReverseMap();

        }
    }
}
