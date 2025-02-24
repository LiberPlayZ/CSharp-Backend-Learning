using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCSharpBackend.Models;

namespace MyCSharpBackend.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(string id);
        Task<User> CreateUser(User user);
        Task<User?> UpdateUserById(string id, User user);
        Task<string?> DeleteUserById(string id);


    }
}