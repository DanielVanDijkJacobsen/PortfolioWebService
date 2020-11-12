using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {

        private readonly IUsersDataService _userDataService;
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;

        public CommentController(IUsersDataService userDataService, ITitlesDataService titleDataService, IMapper mapper)
        {
            _userDataService = userDataService;
            _mapper = mapper;
            _titleDataService = titleDataService;
        }

        //TODO TEST (Completed) Create comment
        [Authorize]
        [HttpPost()]
        public IActionResult CreateComment(CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            return Created("", _titleDataService.CreateComment(newComment));
        }

        //TODO TEST Delete User's Comment
        [Authorize]
        [HttpDelete()]
        public IActionResult DeleteComment(CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);

            var comments = _userDataService.GetCommentsByUserId(newComment.UserId).Result;

            var owns = false;
            foreach (var userid in comments.Where(userid => userid.CommentId == newComment.CommentId))
            {
                owns = true;
            }
            if (owns == false)
                return NotFound();
            if (_userDataService.DeleteComment(newComment.CommentId).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        //TODO TEST (Completed) Update Comment
        [Authorize]
        [HttpPut()]
        public IActionResult UpdateComment(CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            newComment.IsEdited = true;

            if (_titleDataService.UpdateComment(newComment.CommentId, newComment).Result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
