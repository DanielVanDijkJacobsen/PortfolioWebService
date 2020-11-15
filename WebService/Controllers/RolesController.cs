using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.DataService.BusinessLogic;
using WebService.DataService.CustomTypes;
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
            var newRoles = _mapper.Map<SpecialRoles>(role);
            return newRoles.RoleType switch
            {
                RoleType.moderator => Created("", CreateRole(newRoles, "moderator")),
                RoleType.owner => Created("", CreateRole(newRoles, "owner")),
                RoleType.administrator => Created("", CreateRole(newRoles, "administrator")),
                _ => NotFound()
            };
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUserRole(SpecialRoleDto role)
        {
            var roles = _dataService.GetSpecialRolesByUserId(role.UserId).Result;
            if (roles == null)
                return NotFound();
            Console.WriteLine(JsonConvert.SerializeObject(role));
            var updatedRole = _dataService.UpdateSpecialRole(_mapper.Map<SpecialRoles>(role)).Result;
            if (updatedRole == null)
                return NotFound();
            return NoContent();
        }


        private SpecialRoles CreateRole(SpecialRoles role, string type)
        {
            switch (type)
            {
                case "moderator":
                    role.RoleType = RoleType.moderator;
                    break;
                case "owner":
                    role.RoleType = RoleType.owner;
                    break;
                case "administrator":
                    role.RoleType = RoleType.administrator;
                    break;
            }

            _dataService.CreateSpecialRole(role);
            return role;
        }
    }
}
