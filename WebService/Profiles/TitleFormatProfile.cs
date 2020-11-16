using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class TitleFormatProfile : Profile
    {
        public TitleFormatProfile()
        {
            CreateMap<TitleFormats, TitleFormatDto>();
        }
    }
}
