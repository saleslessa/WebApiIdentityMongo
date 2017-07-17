using AutoMapper;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();  
        }
    }
}