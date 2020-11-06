using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataServiceLibrary;

namespace WebService.Controllers
{
    [ApiController]
    public class TitleController
    {
        [HttpGet("titles")]
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
        }
    }
}
