using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class SpecialRolesProfile : Profile
    {
        public SpecialRolesProfile()
        {
            CreateMap<SpecialRoles, SpecialRoleDto>();
            CreateMap<SpecialRoleDto, SpecialRoles>();
        }
    }
}
