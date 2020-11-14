using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
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
        [HttpGet("{id}")]
        public IActionResult GetUserRoles(int id)
        {
            var roles = _dataService.GetSpecialRolesByUserId(id).Result;
            if (roles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<SpecialRoleDto>>(roles));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            var roles = _dataService.GetSpecialRolesByUserId(id).Result;
            if (roles == null)
                return NotFound();
            var deletedRole = _dataService.DeleteSpecialRoleByUserId(id).Result;
            if (deletedRole == null)
                return NotFound();
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateUserRole(SpecialRoleDto role)
        {
            var roles = _dataService.GetSpecialRolesByUserId(role.UserId).Result;
            if (roles == null)
                return NotFound();
            var newRole = _dataService.CreateSpecialRole(_mapper.Map<SpecialRoles>(role)).Result;
            if (newRole == null)
                return NotFound();
            return Created("", _mapper.Map<SpecialRoleDto>(roles.First()));
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUserRole(SpecialRoleDto role)
        {
            var roles = _dataService.GetSpecialRolesByUserId(role.UserId).Result;
            if (roles == null)
                return NotFound();
            var updatedRole = _dataService.UpdateSpecialRole(_mapper.Map<SpecialRoles>(role)).Result;
            if (updatedRole == null)
                return NotFound();
            return NoContent();
        }
    }
}
