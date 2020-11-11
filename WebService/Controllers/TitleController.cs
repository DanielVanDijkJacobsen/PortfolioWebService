using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitleController : ControllerBase
    {
        private readonly ITitlesDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public TitleController(ITitlesDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("popular/movies")]
        public IActionResult GetPopularMovies()
        {
            var titles = _dataService.GetPopularTitles(6, "movie").Result;
            if (titles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitlesForFrontPageDto>>(titles));
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetTitleComments(string id)
        {
            var comments = _dataService.GetCommentsByTitleId(id).Result;
            return Ok(_mapper.Map<ICollection<CommentDto>>(comments));
        }

        [HttpGet("{id}/casts")]
        public IActionResult GetTitleCasts(string id)
        {
            var casts = _dataService.GetCastsByTitleId(id).Result;
            return Ok(_mapper.Map<ICollection<CastDto>>(casts));
        }

        [HttpGet("popular/shows")]
        public IActionResult GetPopularShows()
        {
            var titles =_dataService.GetPopularTitles(6, "tvSeries").Result;
            if (titles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitlesForFrontPageDto>>(titles));
        }

        [HttpGet]
        public IActionResult GetTitles(string query)
        {
            var userId = User.FindFirst("user_id")?.Value;
            IEnumerable<TitleDto> titles;
            IEnumerable<CastInfoDto> casts;

            if (query != null)
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(userId != null ? _dataService.SearchForTitle(int.Parse(userId), query).Result : _dataService.SearchForTitle(null, query).Result);
                casts = _mapper.Map<IEnumerable<CastInfoDto>>(_dataService.SearchByName(query).Result);
            }
            else
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(_dataService.GetAllTitles().Result);
                casts = _mapper.Map<IEnumerable<CastInfoDto>>(_dataService.GetAllCasts().Result);
            }

            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(titles);
            var list = new SearchDto() {Casts = casts, Titles = titles};

            return Ok(list);
        }

        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.GetTitleById(id).Result;

            if (title == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TitleDto>(title));
        }
    }
}
