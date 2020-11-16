using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class NameRatingProfile : Profile
    {
        public NameRatingProfile()
        {
            CreateMap<NameRating, NameRatingDto>();
            CreateMap<NameRatingDto, NameRating>();
        }
    }
}
