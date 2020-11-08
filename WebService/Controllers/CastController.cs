using System.Collections.Generic;
using AutoMapper;
using IMDBDataService.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using WebService.DataTransferModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/cast")]
    public class CastController : ControllerBase
    {
        private readonly ITitlesDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public CastController(ITitlesDataService dataService, IMapper mapper)
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
