using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLibrary;
using Microsoft.AspNetCore.Mvc;
using WebService.DataTransferModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/cast")]
    public class CastController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public CastController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCasts()
        {
            var casts = _dataService.GetCasts();

            return Ok(_mapper.Map<IEnumerable<CastDto>>(casts));
        }


        [HttpGet("{id}", Name = nameof(GetCast))]
        public IActionResult GetCast(string id)
        {
            var cast = _dataService.GetCast(id);

            if (cast == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CastDto>(cast));
        }
    }
}
