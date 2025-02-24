using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCSharpBackend.Models;
using MyCSharpBackend.Repository;

namespace MyCSharpBackend.Controllers

{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
           this._userRepository = userRepository;
        }
    }
}