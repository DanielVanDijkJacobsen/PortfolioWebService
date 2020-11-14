using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/castinfo")]
    public class CastInfoController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public CastInfoController(ICastsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCastInfos()
        {
            var casts = _dataService.GetAllCastInfos().Result;
            if (casts.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastInfoDto>>(casts));
        }

        [HttpGet("{id}")]
        public IActionResult GetCastInfoByCast(string id)
        {
            var castInfo = _dataService.GetCastInfoByCastId(id).Result;
            if (castInfo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastInfoDto>>(castInfo));
        }
    }
}
