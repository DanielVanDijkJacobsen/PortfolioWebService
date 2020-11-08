using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService;
using IMDBDataService.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.DTOs;

namespace WebService.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public RatingsController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateRating(RatingForCreateDto ratingForCreateDto)
        {
            var rating = _mapper.Map<UserRating>(ratingForCreateDto);
            _dataService.RateTitle(rating);
            return Created("", rating);
        }
    }
}
