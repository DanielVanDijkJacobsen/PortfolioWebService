using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;
using WebService.Filters;
using WebService.Services;
using WebService.Utils;
using WebService.Wrappers;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/casts")]
    public class CastsController : ControllerBase
    {
        private readonly ICastsDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CastsController(ICastsDataService dataService, IMapper mapper, IUriService uriService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _uriService = uriService;
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
        public IActionResult GetAllCasts([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var casts = _dataService.GetAllCasts(validFilter).Result;
            var totalRecords = _dataService.CountAll().Result;
            if (casts.Count < 1)
                return NotFound(); 
            var response = PaginationHelper.CreatePagedReponse<CastDto>(_mapper.Map<IEnumerable<CastDto>>(casts), validFilter, totalRecords, _uriService, route);
            return Ok(response);
        }
    }
}
