using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    public class CastController : ControllerBase
    {
        [HttpGet("cast")]
        public JsonResult GetCast()
        {
            var dataService = new DataService();
            var casts = dataService.GetCasts();

            return new JsonResult(casts);
        }

        [HttpGet("cast/{id}")]
        public JsonResult GetCast(string id)
        {
            var dataService = new DataService();
            var cast = dataService.GetCast(id);

            return new JsonResult(cast);
        }
    }
}
