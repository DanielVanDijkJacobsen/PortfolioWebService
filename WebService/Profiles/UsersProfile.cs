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
            CreateMap<Users, UserDto>();
            CreateMap<UserForCreateOrUpdateDto, Users>();
        }
    }
}
