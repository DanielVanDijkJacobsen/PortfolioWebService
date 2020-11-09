using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class SpecialRolesProfile : Profile
    {
        public SpecialRolesProfile()
        {
            CreateMap<SpecialRoles, SpecialRoleDto>();
        }
    }
}
