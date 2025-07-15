using Microsoft.AspNetCore.Mvc;
using ApiDesignDemo.Services;
using ApiDesignDemo.DTOs;
using ApiDesignDemo.Models;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseController<User>
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/users
        [HttpGet]
        public IActionResult GetAll() => Ok(_userService.GetAll());

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult Create(UserDto userDto)
        {
            var user = new User { UserName = userDto.UserName, Email = userDto.Email };
            _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, UserDto userDto)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            _userService.Update(user);
            return NoContent();
        }

        // PATCH: api/users/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UserDto userDto)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            if (userDto.UserName != null) user.UserName = userDto.UserName;
            if (userDto.Email != null) user.Email = userDto.Email;
            _userService.Update(user);
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            _userService.Delete(id);
            return NoContent();
        }
    }
}
