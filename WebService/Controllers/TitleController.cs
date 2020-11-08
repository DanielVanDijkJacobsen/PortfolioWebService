using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataServiceLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitleController : ControllerBase
    {
        private readonly IDataService _dataService;
        //private mapper
        private const int MaxPageSize = 50;

        public TitleController(IDataService dataService /*, Mapper mapper*/)
        {
            _dataService = dataService;
            //private mapper
        }

        [HttpGet]
        public IActionResult GetTitles()
        {
            var titles = _dataService.GetTitles();

            return Ok(titles);
        }


        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.GetTitle(id);
            if (title == null)
            {
                return NotFound();
            }

            //Find mapper 

            return Ok(title); //Needs more code...
        }

        /*[HttpGet("titles")]
        public JsonResult GetTitles()
        {
            var dataService = new DataService();
            var titles = dataService.GetTitles();

            return new JsonResult(titles);
        }

        [HttpGet("titles/{id}")]
        public JsonResult GetTitle(string id)
        {
            var dataService = new DataService();
            var title = dataService.GetTitle(id);

            return new JsonResult(title);
        }*/
    }
}
