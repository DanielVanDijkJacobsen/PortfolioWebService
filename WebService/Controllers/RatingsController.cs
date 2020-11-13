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
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly ICastsDataService _castDataService;
        private readonly ITitlesDataService _titleDataService;
        private readonly IUsersDataService _userDataService;
        private readonly IMapper _mapper;


        public RatingsController(IUsersDataService userDataService, ICastsDataService castDataService, ITitlesDataService titleDataService, IMapper mapper)
        {
            _mapper = mapper;
            _userDataService = userDataService;
            _castDataService = castDataService;
            _titleDataService = titleDataService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateRating(RatingForCreateDto ratingForCreateDto)
        {
            var newRating = _mapper.Map<UserRating>(ratingForCreateDto);
            var rating = _titleDataService.GetUserRatingByUserIdAndTitleId(newRating.UserId, newRating.TitleId).Result;
            if (rating.Count > 0)
                return NotFound();
            var response = _titleDataService.CreateUserRating(_mapper.Map<UserRating>(newRating)).Result;
            _castDataService.UpdateNameRating(newRating.TitleId);
            return Created("", response.ToString());
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateRating(RatingForCreateDto ratingForCreateDto)
        {
            var newRating = _mapper.Map<UserRating>(ratingForCreateDto);
            var rating = _titleDataService.GetUserRatingByUserIdAndTitleId(newRating.UserId, newRating.TitleId).Result;
            if (rating.Count < 1)
                return NotFound();
            if (_titleDataService.UpdateUserRating(newRating) == null)
                return NotFound();
            _castDataService.UpdateNameRating(newRating.TitleId);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteRating(RatingForCreateDto ratingForCreateDto)
        {
            var newRating = _mapper.Map<UserRating>(ratingForCreateDto);
            var rating = _titleDataService.GetUserRatingByUserIdAndTitleId(newRating.UserId, newRating.TitleId).Result;
            if (rating.Count < 1)
                return NotFound();
            if (_titleDataService.DeleteUserRating(newRating) == null)
                return NotFound();
            _castDataService.UpdateNameRating(newRating.TitleId);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetRatings(RatingForCreateDto ratingForCreateDto)
        {
            List<UserRating> userRatings = new List<UserRating>();
            if (ratingForCreateDto.TitleId != null && ratingForCreateDto.UserId > 0)
                userRatings = _titleDataService
                    .GetUserRatingByUserIdAndTitleId(ratingForCreateDto.UserId, ratingForCreateDto.TitleId).Result;
            if (ratingForCreateDto.UserId > 0 && ratingForCreateDto.TitleId == null)
                 userRatings = _userDataService.GetUserRatingsByUserId(ratingForCreateDto.UserId).Result;
            if (ratingForCreateDto.UserId < 1 && ratingForCreateDto.TitleId != null)
                userRatings = _titleDataService.GetUserRatingByTitleId(ratingForCreateDto.TitleId).Result;
            if (userRatings == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<UserRatingDto>>(userRatings));
        }
    }
}
