using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService;
using IMDBDataService.CustomTypes;
using IMDBDataService.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.DTOs;

namespace WebService.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public BookmarksController(IDataService dataService, IMapper mapper)
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
                    bookmark.bookmark_type = BookmarkType.title;
                    break;
                case "actor":
                    bookmark.bookmark_type = BookmarkType.person;
                    break;
                case "user":
                    bookmark.bookmark_type = BookmarkType.user;
                    break;
            }

            _dataService.CreateBookmark(bookmark);
            return bookmark;
        }

    }
}
