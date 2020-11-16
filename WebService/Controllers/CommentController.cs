using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DMO;
using WebService.DTOs;
using WebService.Filters;
using WebService.Services;
using WebService.Utils;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {

        private readonly IUsersDataService _userDataService;
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CommentController(IUsersDataService userDataService, ITitlesDataService titleDataService, IMapper mapper, IUriService uriService)
        {
            _userDataService = userDataService;
            _mapper = mapper;
            _titleDataService = titleDataService;
            _uriService = uriService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment(CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            return Created("", _userDataService.CreateComment(newComment).Result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            if (_userDataService.DeleteComment(id).Result == null)
                return NotFound();
            return NoContent();
        }


        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _userDataService.GetCommentById(id).Result;
            if (comment == null)
                return NotFound();
            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpGet]
        public IActionResult GetComments(int? userId, string titleId, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = 0;
            List<Comments> comments = new List<Comments>();
            if (userId != null)
            {
                comments = _userDataService.GetCommentsByUserId((int)userId, filter).Result;
                totalRecords = _userDataService.GetCommentsByUserId((int)userId).Result.Count;
            } else if (titleId != null)
            {
                comments = _titleDataService.GetCommentsByTitleId(titleId, filter).Result;
                totalRecords = _titleDataService.GetCommentsByTitleId(titleId).Result.Count;
            }

            if (comments.Count < 1)
                return NotFound();

            var response = PaginationHelper.CreatePagedReponse<CommentDto>(_mapper.Map<IEnumerable<CommentDto>>(comments), validFilter, totalRecords, _uriService, route);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateComment(CommentDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            newComment.IsEdited = true;

            if (_userDataService.UpdateComment(newComment.CommentId, newComment).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
