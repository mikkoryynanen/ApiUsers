using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUsers.Database;
using ApiUsers.Helpers;
using ApiUsers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiUsers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserController(IOptions<ApiUsersDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(databaseSettings.Value.UsersCollectionName);
        }

        [HttpGet]
        [Route("create")]
        public async Task<ActionResult<User>> Create()
        {
            var user = new User { ApiKey = Guid.NewGuid() };
            await _usersCollection.InsertOneAsync(user);

            return Created("Create", user);
        }

        [HttpGet]
        public ActionResult<User> Get(string userId)
        {
            var user = _usersCollection.Find(x => x.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return NotFound($"User not found with id {userId}");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}

