using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class CastKnownForProfile : Profile
    {
        public CastKnownForProfile()
        {
            CreateMap<CastKnownFor, CastKnownForDto>();
        }
    }
}
