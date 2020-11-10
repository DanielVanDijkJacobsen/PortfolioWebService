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

        [HttpGet]
        public IActionResult GetTitles(string query)
        {
            var userId = User.FindFirst("user_id")?.Value;
            IEnumerable<TitleDto> titles;
            IEnumerable<CastDto> casts;

            if (query != null)
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(userId != null ? _dataService.SearchForTitle(int.Parse(userId), query).Result : _dataService.SearchForTitle(null, query).Result);
                casts = new List<CastDto>() {new CastDto() {Id = "1", PrimaryName = "dasdasds"}};
            }
            else
            {
                titles = _mapper.Map<IEnumerable<TitleDto>>(_dataService.GetAllTitles().Result);
                casts = new List<CastDto>() { new CastDto() { Id = "1", PrimaryName = "dasdasds" } };
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
