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
    [Route("api/flaggedComments")]
    public class FlaggedCommentController : ControllerBase
    {
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;

        public FlaggedCommentController(ITitlesDataService titleDataService, IMapper mapper)
        {
            _mapper = mapper;
            _titleDataService = titleDataService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult FlagComment(FlaggedCommentForCreateDto flaggedCommentForCreateDto)
        {
            var newFlaggedComment = _mapper.Map<FlaggedComment>(flaggedCommentForCreateDto);

            var exists = _titleDataService.GetFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId).Result;
            if (exists.Count > 0)
                return NotFound();
            var flaggedComment = _titleDataService.FlagComment(newFlaggedComment.FlaggingUser, newFlaggedComment).Result;
            return Created("", flaggedComment.ToString());
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFlagComment(FlaggedCommentForCreateDto flaggedCommentForCreateDto)
        {
            var newFlaggedComment = _mapper.Map<FlaggedComment>(flaggedCommentForCreateDto);

            var exists = _titleDataService.GetFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId).Result;
            if (exists.Count < 1)
                return NotFound();
            _titleDataService.DeleteFlaggedComment(newFlaggedComment.FlaggingUser, newFlaggedComment.CommentId);
            return NoContent();
        }
    }
}
