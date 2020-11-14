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
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;

        public RolesController(IUsersDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserRoles(int id)
        {
            var roles = _dataService.GetSpecialRolesByUserId(id).Result;
            if (roles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<SpecialRoleDto>>(roles));
        }
    }
}
