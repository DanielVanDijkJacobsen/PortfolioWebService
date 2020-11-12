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
        private readonly IMapper _mapper;


        public RatingsController(ICastsDataService castDataService, ITitlesDataService titleDataService, IMapper mapper)
        {
            _mapper = mapper;
            _castDataService = castDataService;
            _titleDataService = titleDataService;
        }

        //COMPLETED Create Rating
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

        //TODO TEST Update Rating
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

        //Todo TEST Delete Rating
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
    }
}
