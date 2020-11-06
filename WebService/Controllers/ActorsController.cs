using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    public class ActorsController : ControllerBase
    {
        [HttpGet("actors")]
        public JsonResult GetActors()
        {
            var dataService = new DataService();
            var actors = dataService.GetActors();

            return new JsonResult(actors);
        }

        [HttpGet("actors/{id}")]
        public JsonResult GetActorById(int id)
        {
            var dataService = new DataService();
            var actor = dataService.GetActorById(id);

            return new JsonResult(actor);
        }
    }
}
