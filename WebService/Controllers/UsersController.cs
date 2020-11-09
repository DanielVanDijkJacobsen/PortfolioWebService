using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebService.DataService.BusinessLogic;
using WebService.DataService.DTO;
using WebService.DTOs;
using WebService.Utils;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IFrameworkDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsersController(IFrameworkDataService dataService, IMapper mapper, IConfiguration config)
        {
            _dataService = dataService;
            _mapper = mapper;
            _config= config;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(_dataService.GetAllUsers().Result); ;
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _mapper.Map<UserDto>(_dataService.GetUserById(id).Result); 

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUser(UserForCreateOrUpdateDto userForCreateOrUpdateDto)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userForCreateOrUpdateDto.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            userForCreateOrUpdateDto.Password = hashed;
            userForCreateOrUpdateDto.Salt = salt;

            var user = _mapper.Map<Users>(userForCreateOrUpdateDto);
            user.Age = 25;

            _dataService.CreateUser(user);
            var jwtToken = GenerateWebToken.Generate(user, _config);
            var userToReturn = _mapper.Map<UserDto>(user);
            userToReturn.JwtToken = jwtToken;
            return Created("", userToReturn);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginUser(UserForCreateOrUpdateDto userForCreateOrUpdateDto)
        {
            var user = _dataService.GetUserByEmail(userForCreateOrUpdateDto.Email).Result;

            if (user == null)
            {
                return NotFound();
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userForCreateOrUpdateDto.Password,
                salt: user.Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var validatedUser = _dataService.ValidateUserByPassword(user.Email, hashed).Result;

            if (validatedUser == null)
            {
                return Unauthorized();
            }

            var jwtToken = GenerateWebToken.Generate(user, _config);
            var userToReturn = _mapper.Map<UserDto>(validatedUser);
            userToReturn.JwtToken = jwtToken;
            return Ok(userToReturn);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserForCreateOrUpdateDto userForCreateOrUpdateDto)
        {
            var user = _mapper.Map<Users>(userForCreateOrUpdateDto);

            if (_dataService.UpdateUser(id, user).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_dataService.DeleteUser(id).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
