using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.CustomTypes;
using WebService.DataService.DTO;
using WebService.DTOs;


namespace WebService.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;

        public BookmarksController(IUsersDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int id)
        {
            if (_dataService.DeleteBookmark(id).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
