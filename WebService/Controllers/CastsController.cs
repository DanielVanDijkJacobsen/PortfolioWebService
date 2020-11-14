using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/casts")]
    public class CastsController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;

        public CastsController(ICastsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{titleId}")]
        public IActionResult GetCasts(string titleId, int? ordering = null)
        {
            List<Casts> casts = new List<Casts>();
            if (ordering != null)
            {
                casts.Add(_dataService.GetCastById(titleId, (int)ordering).Result);
            }
            else
            {
                casts = _dataService.GetCastsByTitleId(titleId).Result;
            }
            if (casts.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<ICollection<CastDto>>(casts));
        }

        [HttpGet]
        public IActionResult GetAllCasts()
        {
            var casts = _dataService.GetAllCasts().Result;
            if (casts.Count < 1)
                return NotFound();
            return Ok(_mapper.Map<ICollection<CastDto>>(casts));
        }
    }
}
