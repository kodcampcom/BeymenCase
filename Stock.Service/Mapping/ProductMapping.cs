using AutoMapper;
using Stock.Core.Models;

namespace Stock.Service.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<Product, ProductRequestDto>().ReverseMap();
            CreateMap<Product, ProductUpdateRequestDto>().ReverseMap();
        }
    }
}
