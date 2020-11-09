using AutoMapper;
using WebService.DataService.DTO;
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
