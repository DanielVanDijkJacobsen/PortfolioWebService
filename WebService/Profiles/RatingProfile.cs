using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<UserRating, UserRatingDto>();
            CreateMap<RatingForCreateDto, UserRating>();
        }
    }
}
