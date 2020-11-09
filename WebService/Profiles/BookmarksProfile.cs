using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<Bookmarks, BookmarkDto>();
            CreateMap<BookmarkForCreateDto, Bookmarks>();
        }
    }
}
