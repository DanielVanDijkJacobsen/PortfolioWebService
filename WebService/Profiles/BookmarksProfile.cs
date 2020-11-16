using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<Bookmarks, BookmarkDto>();
            CreateMap<BookmarkForCreateDto, Bookmarks>();
            CreateMap<BookmarkDto, Bookmarks>();
            CreateMap<Bookmarks, BookmarkForCreateDto > ();
        }
    }
}
