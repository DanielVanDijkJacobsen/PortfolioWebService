using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class CastProfessionProfile : Profile
    {
        public CastProfessionProfile()
        {
            CreateMap<CastProfession, CastProfessionDto>();
        }
    }
}
