using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class FormatProfile : Profile
    {
        public FormatProfile()
        {
            CreateMap<Formats, FormatDto>();
            CreateMap<FormatDto, Formats>();
        }
    }
}
