using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class TitleGenreProfile : Profile
    {
        public TitleGenreProfile()
        {
            CreateMap<TitleGenres, TitleGenreDto>();
        }
    }
}
