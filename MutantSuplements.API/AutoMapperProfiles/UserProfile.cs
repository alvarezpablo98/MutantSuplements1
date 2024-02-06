using AutoMapper;

namespace MutantSuplements.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, DTOs.UserDTOs.UsersDTO>();
            CreateMap<Entities.User, DTOs.UserDTOs.UserDTO>();
            CreateMap<DTOs.UserDTOs.UserToCreateDTO, Entities.User>();
        }
    }
}
