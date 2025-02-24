using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCSharpBackend.Interfaces;
using MyCSharpBackend.Models;
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
        public async Task<IActionResult> GetUsers(){
            var users =  await _userRepository.GetUsers();

            return Ok(users);
        }
    }
}