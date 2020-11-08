using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService.Objects;
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
