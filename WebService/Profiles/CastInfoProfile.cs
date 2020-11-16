using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class CastInfoProfile : Profile
    {
        public CastInfoProfile()
        {
            CreateMap<CastInfo, CastInfoDto>();
        }
    }
}
