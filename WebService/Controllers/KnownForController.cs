using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/knownfor")]
    public class KnownForController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;

        public KnownForController(ICastsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetCastKnownForByCast(string id)
        {
            var castKnownFor = _dataService.GetCastKnownForByCastId(id).Result;
            if (castKnownFor == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastKnownForDto>>(castKnownFor));
        }
    }
}
