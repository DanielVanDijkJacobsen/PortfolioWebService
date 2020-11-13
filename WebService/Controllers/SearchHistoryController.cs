using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DTOs;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/searchhistory")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;

        public SearchHistoryController(IUsersDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        //COMPLETED Show User's searchhistory
        [Authorize]
        [HttpGet("/{id}")]
        public IActionResult GetUserSearchHistory(int id)
        {
            var searchHistory = _dataService.GetSearchHistoryByUserId(id).Result;
            if (searchHistory == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<SearchHistoryDto>>(searchHistory));
        }

    }
}
