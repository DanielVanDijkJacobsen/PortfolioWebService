using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.CustomTypes;
using WebService.DataService.DMO;
using WebService.DTOs;
using WebService.Filters;
using WebService.Services;
using WebService.Utils;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookmarkController : ControllerBase
    {
        private readonly IUsersDataService _userDataService;
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public BookmarkController(IUsersDataService userDataService, ITitlesDataService titleDataService, IMapper mapper, IUriService uriService)
        {
            _userDataService = userDataService;
            _mapper = mapper;
            _titleDataService = titleDataService;
            _uriService = uriService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult BookmarkTitle(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var userId = int.Parse(User.FindFirst("user_id")?.Value);
            bookmarkForCreateDto.UserId = userId;
            var newBookmark = _mapper.Map<Bookmarks>(bookmarkForCreateDto);
            var exist = _titleDataService.GetBookmark(newBookmark.TypeId, newBookmark.UserId).Result;
            if (exist.Count > 0)
                return NotFound();
            return bookmarkForCreateDto.BookmarkType switch
            {
                BookmarkType.title => Created("", CreateBookmark(newBookmark, "title")),
                BookmarkType.person => Created("", CreateBookmark(newBookmark, "person")),
                _ => NotFound()
            };
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteBookmark(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var bookmark = _mapper.Map<Bookmarks>(bookmarkForCreateDto);
            if (_userDataService.DeleteBookmark(bookmark.UserId, bookmark.TypeId).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{userId}")]
        public IActionResult GetBookmarks(int? userId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            List<Bookmarks> bookmarks;
            int totalRecords = 0;
            if (userId != null)
            {
                bookmarks = _userDataService.GetBookmarksByUserId((int)userId, validFilter).Result;
                totalRecords = _userDataService.GetBookmarksByUserId((int)userId).Result.Count;
                if (bookmarks.Count < 1)
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

            var response = PaginationHelper.CreatePagedReponse<BookmarkDto>(_mapper.Map<IEnumerable<BookmarkDto>>(bookmarks), validFilter, totalRecords, _uriService, route);
            return Ok(response);
        }

        private Bookmarks CreateBookmark(Bookmarks bookmark, string type)
        {
            switch (type)
            {
                case "title":
                    bookmark.BookmarkType = BookmarkType.title;
                    break;
                case "actor":
                    bookmark.BookmarkType = BookmarkType.person;
                    break;
                case "user":
                    bookmark.BookmarkType = BookmarkType.user;
                    break;
            }
            _titleDataService.CreateBookmark(bookmark);
            return bookmark;
        }
    }
}
