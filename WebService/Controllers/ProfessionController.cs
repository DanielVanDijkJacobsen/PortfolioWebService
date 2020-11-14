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
    [Route("api/professions")]
    public class ProfessionController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;

        public ProfessionController(ICastsDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetCastProfessionByCast(string id)
        {
            var castProfession = _dataService.GetCastProfessionByCastId(id).Result;
            if (castProfession == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CastProfessionDto>>(castProfession));
        }
    }
}
