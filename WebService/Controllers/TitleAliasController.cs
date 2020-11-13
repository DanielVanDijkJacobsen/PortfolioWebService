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
    [Route("api/titlealias")]
    public class TitleAliasController : ControllerBase
    {
        private readonly ITitlesDataService _dataService;
        private readonly IMapper _mapper;

        public TitleAliasController(ITitlesDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("/{id}")]
        public IActionResult GetTitleAlias(string id)
        {
            var titleAlias = _dataService.GetTitleAliasByTitleId(id).Result;
            if (titleAlias == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<TitleAliasDto>>(titleAlias));
        }
    }
}
