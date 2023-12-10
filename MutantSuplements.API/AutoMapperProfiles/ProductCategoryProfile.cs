using AutoMapper;

namespace MutantSuplements.API.AutoMapperProfiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<Entities.ProductCategory, DTOs.ProductCategoryDTOs.ProductCategoryDTO>();
            CreateMap<DTOs.ProductCategoryDTOs.ProductCategoryAddDTO, Entities.ProductCategory>();

        }
    }
}
