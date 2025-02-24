using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MyCSharpBackend.Interfaces;
using MyCSharpBackend.Models;

namespace MyCSharpBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDbService _mongoService;
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbService mongoService)
        {
            _mongoService = mongoService;
            _users = _mongoService.GetCollection<User>("users");
        }

        public async Task<User> CreateUser(User user)
        {
            await _users.InsertOneAsync(user);

            return user;
        }



        public async Task<User?> GetUserById(string id)
        {
            var user = await _users.Find(u => u.Id == id).FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _users.Find(_ => true).ToListAsync();

            return users;
        }

        public async Task<User?> UpdateUserById(string id, User updateUser)
        {
            var result = await _users.ReplaceOneAsync(
              u => u.Id == id,
              updateUser);

            if (result.MatchedCount == 0)
            {
                return null;
            }
            return updateUser;

        }

        public async Task<string?> DeleteUserById(string id)
        {
            var result = await _users.DeleteOneAsync(u => u.Id == id);

            if (result.DeletedCount == 0)
            {
                return null;
            }
            return "user deleted succesfully";
        }
    }
}