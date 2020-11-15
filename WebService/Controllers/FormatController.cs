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
        public IActionResult GetAllFormats()
        {
            var formats = _titleDataService.GetAllFormats().Result;
            if (formats.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<FormatDto>>(formats));
        }

        [HttpGet("{id}")]
        public IActionResult GetFormatByTitleId(string id)
        {
            var format = _titleDataService.GetFormatByTitleId(id).Result;
            if (format == null)
                return NotFound();
            return Ok(_mapper.Map<FormatDto>(format));
        }

    }
}
