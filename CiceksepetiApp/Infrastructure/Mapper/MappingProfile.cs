using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace CiceksepetiApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            CreateMap<CompanyDto, Company>();

            CreateMap<RatingDtoForInsertion, Rating>();
            CreateMap<RatingDtoForUpdate, Rating>().ReverseMap();
        }
    }
}