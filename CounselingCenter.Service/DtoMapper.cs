using AutoMapper;
using CounselingCenter.Core.Dtos;
using CounselingCenter.Core.Models;

namespace CounselingCenter.Service
{
    class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<AppUserDto, AppUser>().ReverseMap();
        }
    }
}