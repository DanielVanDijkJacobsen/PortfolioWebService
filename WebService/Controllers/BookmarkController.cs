using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.CustomTypes;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookmarkController : ControllerBase
    {
        private readonly IUsersDataService _userDataService;
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;

        public BookmarkController(IUsersDataService userDataService, ITitlesDataService titleDataService, IMapper mapper)
        {
            _userDataService = userDataService;
            _mapper = mapper;
            _titleDataService = titleDataService;
        }

        //TODO TEST (Completed) Create Title Bookmark
        [Authorize]
        [HttpPost("title")]
        public IActionResult BookmarkTitle(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var newBookmark = _mapper.Map<Bookmarks>(bookmarkForCreateDto);
            var exist = _titleDataService.GetBookmark(newBookmark.TypeId, newBookmark.UserId).Result;
            if (exist.Count > 0)
                return NotFound();
            return Created("", CreateBookmark(newBookmark, "title"));
        }

        //TODO TEST Create Actor bookmark
        [Authorize]
        [HttpPost("actor")]
        public IActionResult BookmarkActor(BookmarkForCreateDto bookmarkForCreateDto)
        {
            var newBookmark = _mapper.Map<Bookmarks>(bookmarkForCreateDto);
            var exist = _titleDataService.GetBookmark(newBookmark.TypeId, newBookmark.UserId).Result;
            if (exist.Count > 0)
                return NotFound();
            return Created("", CreateBookmark(newBookmark, "actor"));
        }

        //TODO TEST Delete Title Bookmarks
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

        [HttpGet]
        public IActionResult GetBookmarks(BookmarkForCreateDto bookmarkForCreateDto)
        {
            List<Bookmarks> bookmarks = new List<Bookmarks>();
            if (bookmarkForCreateDto.UserId > 0 && bookmarkForCreateDto.TypeId != null)
                bookmarks = _titleDataService.GetBookmark(bookmarkForCreateDto.TypeId, bookmarkForCreateDto.UserId)
                    .Result;
            else if (bookmarkForCreateDto.UserId > 0 && bookmarkForCreateDto.TypeId == null)
                bookmarks = _userDataService.GetBookmarksByUserId(bookmarkForCreateDto.UserId).Result;
            else if (bookmarkForCreateDto.UserId < 1 && bookmarkForCreateDto.TypeId == null)
                return NotFound();
            return Ok(_mapper.Map<BookmarkDto>(bookmarks));
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
