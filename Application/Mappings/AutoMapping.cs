using AutoMapper;
using Contracts.DTOs.UserModel;
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
        }
    }
}
