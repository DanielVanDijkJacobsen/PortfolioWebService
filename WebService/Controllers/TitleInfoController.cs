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
    [Route("api/titleinfo")]
    public class TitleInfoController : ControllerBase
    {
        private readonly ITitlesDataService _dataService;
        private readonly IMapper _mapper;

        public TitleInfoController(ITitlesDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTitleInfo(string id)
        {
            var titleInfo = _dataService.GetTitleInfoByTitleId(id).Result;
            if (titleInfo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitleInfoDto>>(titleInfo));
        }
    }
}
