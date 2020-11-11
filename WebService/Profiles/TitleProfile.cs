using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Titles, TitleDto>();
            CreateMap<Titles, TitlesForFrontPageDto>();
        }
    }
}
