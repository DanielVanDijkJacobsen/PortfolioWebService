using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/cast")]
    public class CastController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public CastController(ICastsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCasts()
        {
            var casts = _dataService.GetAllCasts().Result;
            return Ok(_mapper.Map<IEnumerable<CastDto>>(casts));
        }

        [HttpGet("{id}/info")]
        public IActionResult GetCastInfoByCast(string id)
        {
            var castInfo = _dataService.GetCastInfoByCastId(id).Result;
            if (castInfo == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastInfoDto>>(castInfo));
        }

        [HttpGet("{id}/profession")]
        public IActionResult GetCastProfessionByCast(string id)
        {
            var castProfession = _dataService.GetCastProfessionByCastId(id).Result;
            if (castProfession == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastProfessionDto>>(castProfession));
        }

        [HttpGet("{id}/knownfor")]
        public IActionResult GetCastKnownForByCast(string id)
        {
            var castKnownFor = _dataService.GetCastKnownForByCastId(id).Result;
            if (castKnownFor == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastProfessionDto>>(castKnownFor));
        }

        [HttpGet("{id}", Name = nameof(GetCast))]
        public IActionResult GetCast(string id)
        {
            var cast = _dataService.GetCastById(id).Result;

            if (cast == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CastDto>(cast));
        }
    }
}
