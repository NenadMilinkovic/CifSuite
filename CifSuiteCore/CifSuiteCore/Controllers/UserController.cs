using CifSuiteCore.Repository;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CifSuiteCore.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            User result = await _userRepository.CreateUser(user);

            if (result == null)
                return Conflict();

            return CreatedAtRoute("GetUser", new { id = result.Id }, result);
        }

    }
}
