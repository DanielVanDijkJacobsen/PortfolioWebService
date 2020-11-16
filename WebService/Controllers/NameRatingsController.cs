using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/nameratings")]
    public class NameRatingsController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;

        public NameRatingsController(ICastsDataService dataService, IMapper mapper)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetNameRating(string id)
        {
            var nameRating = _dataService.GetNameRatingByCastId(id).Result;
            if (nameRating == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<NameRatingDto>>(nameRating));
        }
    }
}
