using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCSharpBackend.Dtos;
using MyCSharpBackend.Models;

namespace MyCSharpBackend.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromCreateUserDto(this CreateUserDto createUserDto)
        {

            return new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Age = createUserDto.Age
            };
        }
    }
}