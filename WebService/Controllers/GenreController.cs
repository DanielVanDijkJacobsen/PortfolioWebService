using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("/{id}")]
        public IActionResult GetGenreByTitleId(string id)
        {
            var genre = _titleDataService.GetGenreByTitleId(id).Result;
            if (genre == null)
                return NotFound();
            return Ok(_mapper.Map<GenreDto>(genre));
        }
    }
}
