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

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment(CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var newComment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            return Created("", _userDataService.CreateComment(newComment).Result);
        }

        [Authorize]
        [HttpDelete]
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
        public IActionResult GetComments(CommentForGetDto commentForGetDto)
        {
            List<Comments> comments = new List<Comments>();
            if(commentForGetDto.TitleId != null)
                comments = _titleDataService.GetCommentsByTitleId(commentForGetDto.TitleId).Result;
            if(commentForGetDto.UserId != 0)
                comments = _userDataService.GetCommentsByUserId(commentForGetDto.UserId).Result;
            if (comments.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<ICollection<CommentDto>>(comments));
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
