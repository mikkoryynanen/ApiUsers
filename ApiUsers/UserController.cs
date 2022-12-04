using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUsers.Database;
using ApiUsers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [Route("create")]
        public async Task<ActionResult<User>> Create()
        {
            var user = new User { ID = Guid.NewGuid(), ApiKey = Guid.NewGuid() };
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();

            return Created("Create", user);
        }

        [HttpGet]
        public ActionResult<User> Get(Guid userId)
        {
            var user = _userContext.Users.FirstOrDefault(u => u.ID == userId);
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

