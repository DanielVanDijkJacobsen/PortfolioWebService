using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;

        public GenreController(ITitlesDataService titleDataService, IMapper mapper)
        {
            _mapper = mapper;
            _titleDataService = titleDataService;
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreByTitleId(string id)
        {
            var genre = _titleDataService.GetGenreByTitleId(id).Result;
            if (genre == null)
                return NotFound();
            return Ok(_mapper.Map<GenreDto>(genre));
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _titleDataService.GetAllGenres().Result;
            if (genres.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<GenreDto>>(genres));
        }
    }
}
