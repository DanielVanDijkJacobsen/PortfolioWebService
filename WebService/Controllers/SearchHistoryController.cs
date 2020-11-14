using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;
using WebService.Filters;
using WebService.Services;
using WebService.Utils;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/searchhistory")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public SearchHistoryController(IUsersDataService dataService, IMapper mapper, IUriService uriService)
        {
            _dataService = dataService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserSearchHistory([FromQuery] PaginationFilter filter)
        {
            var userId = User.FindFirst("user_id")?.Value;
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var searchHistory = _dataService.GetSearchHistoryByUserId(int.Parse(userId), validFilter).Result;
            var totalRecords = _dataService.GetSearchHistoryByUserId(int.Parse(userId)).Result.Count;
            if (searchHistory == null || searchHistory.Count < 1)
                return NotFound();
            var response = PaginationHelper.CreatePagedReponse<SearchHistoryDto>(_mapper.Map<IEnumerable<SearchHistoryDto>>(searchHistory), validFilter, totalRecords, _uriService, route);

            return Ok(response);
        }
    }
}
