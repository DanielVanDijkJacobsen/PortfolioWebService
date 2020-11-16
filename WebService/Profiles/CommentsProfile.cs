using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comments, CommentDto>();
            CreateMap<CommentForCreateOrUpdateDto, Comments>();
            CreateMap<CommentDto, Comments>();
        }
    }
}
