using AutoMapper;
using WebService.DataService.DMO;
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
