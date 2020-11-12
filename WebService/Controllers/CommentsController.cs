using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;

        public CommentsController(IUsersDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("flag")]
        public IActionResult FlagComment(FlaggedCommentForCreateDto flaggedCommentForCreateDto)
        {
            var comment = _mapper.Map<FlaggedComment>(flaggedCommentForCreateDto);
            _dataService.FlagComment(comment);
            return Created("", comment.ToString());
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateComment(int id, CommentForCreateOrUpdateDto commentForCreateOrUpdateDto)
        {
            var comment = _mapper.Map<Comments>(commentForCreateOrUpdateDto);
            if (_dataService.UpdateComment(id, comment).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
