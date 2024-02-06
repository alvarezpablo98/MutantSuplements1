using AutoMapper;
using MutantSuplements.API.DTOs.OrderDTOs;
using MutantSuplements.API.Entities;

namespace MutantSuplements.API.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Entities.Order, DTOs.OrderDTOs.OrderDTO>();
            CreateMap<DTOs.OrderDTOs.OrderDTO, Entities.Order>();
            //CreateMap<Entities.Order, DTOs.OrderDTOs.OrderToCreateDto>();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails ?? new List<OrderDetail>()));
            //CreateMap<DTOs.OrderDTOs.OrderToCreateDto, Entities.Order>();
            CreateMap<DTOs.OrderDetailDTOs.OrderDetailDTO, Entities.OrderDetail>();

            CreateMap<DTOs.OrderDTOs.OrderToCreateDTO, Entities.Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<DTOs.OrderDTOs.OrderToUpdateDTO, Entities.Order>()
                    .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

        }
    }
}
