using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService.Objects;
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
