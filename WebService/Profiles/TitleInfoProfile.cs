using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class TitleInfoProfile : Profile
    {
        public TitleInfoProfile()
        {
            CreateMap<TitleInfo, TitleInfoDto>();
        }
    }
}
