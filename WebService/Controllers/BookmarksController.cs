using AutoMapper;
using IMDBDataService.BusinessLogic;
using IMDBDataService.CustomTypes;
using IMDBDataService.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DTOs;


namespace WebService.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IFrameworkDataService _dataService;
        private readonly IMapper _mapper;

        public BookmarksController(IFrameworkDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("title")]
        public IActionResult BookmarkTitle(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var bookmark = CreateBookmark(bookmarkForCreateDto, "title");
            return Created("", bookmark);
        }

        [Authorize]
        [HttpPost("actor")]
        public IActionResult BookmarkActor(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var bookmark = CreateBookmark(bookmarkForCreateDto, "actor");
            return Created("", bookmark);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int id)
        {
            if (_dataService.DeleteBookmark(id).Result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private Bookmarks CreateBookmark(BookmarkForCreateDto bookmarkForCreateDto, string type)
        {
            var bookmark = _mapper.Map<Bookmarks>(bookmarkForCreateDto);

            switch (type)
            {
                case "title":
                    bookmark.BookmarkType= BookmarkType.title;
                    break;
                case "actor":
                    bookmark.BookmarkType = BookmarkType.person;
                    break;
                case "user":
                    bookmark.BookmarkType = BookmarkType.user;
                    break;
            }

            _dataService.CreateBookmark(bookmark);
            return bookmark;
        }

    }
}
