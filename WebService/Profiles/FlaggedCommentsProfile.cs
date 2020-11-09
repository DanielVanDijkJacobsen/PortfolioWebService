using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class FlaggedCommentsProfile : Profile
    {
        public FlaggedCommentsProfile()
        {
            CreateMap<FlaggedComment, FlaggedCommentDto>();
            CreateMap<FlaggedCommentForCreateDto, FlaggedComment>();
        }
    }
}
