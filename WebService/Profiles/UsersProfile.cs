using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;
using WebService.Resolvers;

namespace WebService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UserDto>()
                .ForMember(
                    dest => dest.Name, 
                    opt => opt.MapFrom<UserNameResolver>());
            CreateMap<UserForCreateOrUpdateDto, Users>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            ).ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            );
        }
    }
}
