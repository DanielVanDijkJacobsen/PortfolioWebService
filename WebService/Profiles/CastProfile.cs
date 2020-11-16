using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<Casts, CastDto>();
        }
    }
}
