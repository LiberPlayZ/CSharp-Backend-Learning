using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MyCSharpBackend.Dtos;
using MyCSharpBackend.Interfaces;
using MyCSharpBackend.Models;
using MyCSharpBackend.Mappers;
namespace MyCSharpBackend.Controllers

{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest(new { message = "Invalid ID format" });
            }

            var user = await _userRepository.GetUserById(id);

            if (user is null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            var convertToUser = user.ToUserFromCreateUserDto();
            var userCreated = await _userRepository.CreateUser(convertToUser);
            return CreatedAtAction(nameof(GetUserById), new { id = userCreated.Id }, userCreated);
        }
    }
}