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
    [Route("api/formats")]
    public class FormatController : ControllerBase
    {
        private readonly ITitlesDataService _titleDataService;
        private readonly IMapper _mapper;

        public FormatController(ITitlesDataService titleDataService, IMapper mapper)
        {
            _mapper = mapper;
            _titleDataService = titleDataService;
        }

        [HttpGet]
        public IActionResult GetFormatByTitleId(string id)
        {
            var genre = _titleDataService.GetFormatByTitleId(id).Result;
            if (genre == null)
                return NotFound();
            return Ok(_mapper.Map<FormatDto>(genre));
        }
    }
}
