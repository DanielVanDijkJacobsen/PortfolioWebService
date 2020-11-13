using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitleController : ControllerBase
    {
        private readonly ITitlesDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public TitleController(ITitlesDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        //TODO (Completed) Get Popular movies
        [HttpGet("popular")]
        public IActionResult GetPopular(string type)
        {
            var titles = _dataService.GetPopularTitles(6, type).Result;
            if (titles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitlesForFrontPageDto>>(titles));
        }

        //TODO (Completed) Get Titles
        [HttpGet]
        public IActionResult GetTitles(string query)
        {
            var userId = User.FindFirst("user_id")?.Value;
            IEnumerable<TitleDto> titles;
            IEnumerable<CastInfoDto> casts;

            if (query != null)
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(userId != null ? _dataService.SearchForTitle(int.Parse(userId), query).Result : _dataService.SearchForTitle(null, query).Result);
                casts = _mapper.Map<IEnumerable<CastInfoDto>>(_dataService.SearchByName(query).Result);
            }
            else
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(_dataService.GetAllTitles().Result);
                casts = _mapper.Map<IEnumerable<CastInfoDto>>(_dataService.GetAllCasts().Result);
            }
            var list = new SearchDto() {Casts = casts, Titles = titles};
            return Ok(list);
        }

        //TODO (Completed) Get Title
        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.GetTitleById(id).Result;
            if (title == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TitleDto>(title));
        }

        /*
        [HttpGet("popular/shows")]
        public IActionResult GetPopularShows()
        {
            var titles =_dataService.GetPopularTitles(6, "tvSeries").Result;
            if (titles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitlesForFrontPageDto>>(titles));
        }

        [HttpGet("{id}/info")]
        public IActionResult GetTitleInfo(string id)
        {
            var titleInfo = _dataService.GetTitleInfoByTitleId(id).Result;
            if (titleInfo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitleInfoDto>>(titleInfo));
        }

        [HttpGet("{id}/alias")]
        public IActionResult GetTitleAlias(string id)
        {
            var titleAlias = _dataService.GetTitleAliasByTitleId(id).Result;
            if (titleAlias == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitleAliasDto>>(titleAlias));
        }


        [HttpGet("{id}/casts")]
        public IActionResult GetTitleCasts(string id)
        {
            var casts = _dataService.GetCastsByTitleId(id).Result;
            return Ok(_mapper.Map<ICollection<CastDto>>(casts));
        }

        [HttpGet("{id}/format")]
        public IActionResult GetTitleFormat(string id)
        {
            var titleFormat = _dataService.GetTitleFormatByTitleId(id).Result;
            if (titleFormat == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitleFormatDto>>(titleFormat));
        }
    

        [HttpGet("popular/movies")]
        public IActionResult GetPopularMovies()
        {
            var titles = _dataService.GetPopularTitles(6, "movie").Result;
            if (titles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitlesForFrontPageDto>>(titles));
        }

        
        [Authorize]
        [HttpPost("{tid}/ratings{uid}&{score}")]
        public IActionResult CreateRating(string tid, int uid, float score)
        {
            var rating = _dataService.GetUserRatingByUserIdAndTitleId(uid, tid).Result;
            if (rating.Count > 0)
                return NotFound();
            var newRating = new UserRatingDto()
            {
                UserId = uid, 
                TitleId = tid,
                Score = score
            };
            var response = _dataService.CreateUserRating(_mapper.Map<UserRating>(newRating)).Result;
            return Created("", response.ToString());
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetTitleComments(string id)
        {
            var comments = _dataService.GetCommentsByTitleId(id).Result;
            return Ok(_mapper.Map<ICollection<CommentDto>>(comments));
        }


        [Authorize]
        [HttpPost("{tid}/comments{uid}&{comment}")]
        public IActionResult CreateComment(string tid, int uid, string comment)
        {
            var newComment = new CommentForCreateOrUpdateDto()
            {
                TitleId = tid, 
                UserId = uid, 
                Comment = comment,
                ParentCommentId = null
            };
            return Created("", _dataService.CreateComment(_mapper.Map<Comments>(newComment)));
        }

        [Authorize]
        [HttpPut("{tid}/comments{uid}&{cid}&{updatedComment}")]
        public IActionResult UpdateComment(string tid, int uid, int cid, string updatedComment)
        {
            var newComment = new CommentForCreateOrUpdateDto()
            {
                TitleId = tid,
                UserId = uid,
                Comment = updatedComment,
                ParentCommentId = null
            };
            var comment = _mapper.Map<Comments>(newComment);

            if (_dataService.UpdateComment(cid, comment).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }


        [Authorize]
        [HttpPost("{tid}/comments/{cid}&{uid}")]
        public IActionResult FlagComment(int uid, int cid)
        {
            var exists = _dataService.GetFlaggedComment(uid, cid).Result;
            if (exists.Count > 0)
                return NotFound();
            var flagComment = new FlaggedCommentForCreateDto()
            {
                CommentId = cid, 
                FlaggingUser = uid,
            };
            var comment = _mapper.Map<FlaggedComment>(flagComment);
            var flaggedComment = _dataService.FlagComment(uid, comment).Result;
            return Created("", flaggedComment.ToString());
        }


        [Authorize]
        [HttpDelete("{tid}/comments/{cid}&{uid}")]
        public IActionResult DeleteFlagComment(int uid, int cid)
        {
            var exists = _dataService.GetFlaggedComment(uid, cid).Result;
            if (exists.Count < 1)
                return NotFound();
            _dataService.DeleteFlaggedComment(uid, cid);
            return NoContent();
        }


        [Authorize]
        [HttpPost("{tid}/bookmarks{uid}")]
        public IActionResult CreateBookmark(string tid, int uid)
        {
            var exist = _dataService.GetBookmark(tid, uid).Result;
            if (exist.Count> 0)
                return NotFound();
            var bookmark = new BookmarkForCreateDto()
            {
                BookmarkType = BookmarkType.title,
                TypeId = tid,
                UserId = uid
            };
            return Created("", _dataService.CreateBookmark(_mapper.Map<Bookmarks>(bookmark)));
        }
        */

    }
}
