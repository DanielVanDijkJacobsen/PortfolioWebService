using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DataServiceLibrary;
using Microsoft.Extensions.DependencyInjection;
using WebService.DataTransferModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitleController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 50;

        public TitleController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTitles()
        {
            var titles = _dataService.GetTitles();

            return Ok(_mapper.Map<IEnumerable<TitleDto>>(titles));
        }


        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.GetTitle(id);
            
            if (title == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TitleDto>(title));
        }

    }
}
