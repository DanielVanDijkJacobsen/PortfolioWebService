using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private readonly IUsersDataService _dataService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsersController(IUsersDataService dataService, IMapper mapper, IConfiguration config)
        {
            _dataService = dataService;
            _mapper = mapper;
            _config= config;
        }

        //COMPLETED Get Users
        [Authorize]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(_dataService.GetAllUsers().Result);
            return Ok(users);
        }

        //COMPLETED Get User
        [Authorize]
        [HttpGet("/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _mapper.Map<UserDto>(_dataService.GetUserById(id).Result); 

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //COMPLETED Create user
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

            var createdUser = _dataService.CreateUser(user).Result;
            var jwtToken = GenerateWebToken.Generate(createdUser, _config);
            var userToReturn = _mapper.Map<UserDto>(createdUser);
            userToReturn.JwtToken = jwtToken;
            return Created("", userToReturn);
        }

        //COMPLETED Login user
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

            var jwtToken = GenerateWebToken.Generate(validatedUser, _config);
            var userToReturn = _mapper.Map<UserDto>(validatedUser);
            userToReturn.JwtToken = jwtToken;
            return Ok(userToReturn);
        }

        //COMPLETED Update User
        [Authorize]
        [HttpPut]
        public IActionResult UpdateUser(int id, UserForCreateOrUpdateDto userForCreateOrUpdateDto)
        {
            var user = _mapper.Map<Users>(userForCreateOrUpdateDto);

            if (_dataService.UpdateUser(id, user).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        //COMPLETED Delete User
        [Authorize]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = _dataService.GetUserById(id).Result;
            if (user == null)
                return NotFound();
            _dataService.DeleteUser(id);
            return NoContent();
        }


        /*
        [Authorize]
        [HttpDelete("{uid}/bookmarks/titles{tid}")]
        public IActionResult DeleteBookmark(int uid, string tid)
        {
            if (_dataService.DeleteBookmark(uid, tid).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        
        //COMPLETED Show User's Roles
        [Authorize]
        [HttpGet("/{id}/roles")]
        public IActionResult GetUserRoles(int id)
        {
            var roles = _dataService.GetSpecialRolesByUserId(id).Result;
            if (roles == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<SpecialRoleDto>>(roles));
        }

        
        //COMPLETED Show User's searchhistory
        [Authorize]
        [HttpGet("/{id}/searchhistory")]
        public IActionResult GetUserSearchHistory(int id)
        {
            var searchHistory = _dataService.GetSearchHistoryByUserId(id).Result;
            if (searchHistory == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<SearchHistoryDto>>(searchHistory));
        }

        [Authorize]
        [HttpGet("{id}/bookmarks")]
        public IActionResult GetUserBookmarks(int id)
        {
            var bookmarks = _dataService.GetBookmarksByUserId(id).Result;
            if (bookmarks == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<BookmarkDto>>(bookmarks));
        }

        [Authorize]
        [HttpGet("{id}/comments")]
        public IActionResult GetUserComments(int id)
        {
            var comments = _dataService.GetCommentsByUserId(id).Result;
            if (comments == null)
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
        }

        [Authorize]
        [HttpGet("{id}/comments/{cid}")]
        public IActionResult GetUserComment(int id, int cid)
        {
            //If comments change to FlaggingUser + Ordering, then change this to use both id and cid
            var comment = _dataService.GetCommentById(cid).Result;
            if (comment == null)
                return NotFound();
            return Ok(_mapper.Map<CommentDto>(comment));
        }


        [Authorize]
        [HttpDelete("{uid}/comments{cid}")]
        public IActionResult DeleteComment(int uid, int cid)
        {
            var comments = _dataService.GetCommentsByUserId(uid).Result;
            var owns = false;
            foreach (var userid in comments.Where(userid => userid.CommentId == cid))
            {
                owns = true;
            }
            if (owns == false)
                return NotFound();
            if (_dataService.DeleteComment(cid).Result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

         */
    }
}
