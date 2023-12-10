using AutoMapper;

namespace MutantSuplements.API.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, DTOs.ProductDTOs.ProductDTO>();
            CreateMap<DTOs.ProductDTOs.ProductToCreateDTO, Entities.Product>();
            CreateMap<Entities.Product, DTOs.ProductDTOs.ProductToCreateDTO > ();
            CreateMap<DTOs.ProductDTOs.ProductUpdateDTO, Entities.Product>();
        }
    }
}
    