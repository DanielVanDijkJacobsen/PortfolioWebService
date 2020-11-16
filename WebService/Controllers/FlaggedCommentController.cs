using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/flaggedComments")]
    public class FlaggedCommentController : ControllerBase
    {
        private readonly IUsersDataService _usersDataService;
        private readonly IMapper _mapper;

        public FlaggedCommentController(IUsersDataService usersDataService, IMapper mapper)
        {
            _mapper = mapper;
            _usersDataService = usersDataService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult FlagComment(FlaggedCommentForCreateDto flaggedCommentForCreateDto)
        {
            var newFlaggedComment = _mapper.Map<FlaggedComment>(flaggedCommentForCreateDto);

            var exists = _usersDataService.GetFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId).Result;
            if (exists.Count > 0)
                return NotFound();
            var flaggedComment = _usersDataService.FlagComment(newFlaggedComment).Result;
            return Created("", flaggedComment.ToString());
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFlagComment(FlaggedCommentForCreateDto flaggedCommentForCreateDto)
        {
            var newFlaggedComment = _mapper.Map<FlaggedComment>(flaggedCommentForCreateDto);

            var exists = _usersDataService.GetFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId).Result;
            if (exists.Count < 1)
                return NotFound();
            _usersDataService.DeleteFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId);
            return NoContent();
        }
    }
}
