using Microsoft.AspNetCore.Mvc;
using ApiDesignDemo.Services;
using ApiDesignDemo.DTOs;
using ApiDesignDemo.Models;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/friends")]
    public class FriendshipsController : BaseController<Friendship>
    {
        private readonly FriendshipService _friendshipService;
        public FriendshipsController(FriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet]
        public IActionResult GetFriends(int userId) => Ok(_friendshipService.GetByUserId(userId));

        [HttpGet("{id}")]
        public IActionResult GetById(int userId, int id)
        {
            var friendship = _friendshipService.GetByUserId(userId).FirstOrDefault(f => f.Id == id);
            if (friendship == null) return NotFound();
            return Ok(friendship);
        }

        [HttpPost]
        public IActionResult AddFriend(int userId, FriendshipDto friendshipDto)
        {
            var friendship = new Friendship { UserId = userId, FriendId = friendshipDto.FriendId, CreatedAt = friendshipDto.CreatedAt };
            _friendshipService.Add(friendship);
            return CreatedAtAction(nameof(GetById), new { userId = userId, id = friendship.Id }, friendship);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int userId, int id, FriendshipDto friendshipDto)
        {
            var friendship = _friendshipService.GetByUserId(userId).FirstOrDefault(f => f.Id == id);
            if (friendship == null) return NotFound();
            friendship.FriendId = friendshipDto.FriendId;
            friendship.CreatedAt = friendshipDto.CreatedAt;
            _friendshipService.Add(friendship);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int userId, int id, FriendshipDto friendshipDto)
        {
            var friendship = _friendshipService.GetByUserId(userId).FirstOrDefault(f => f.Id == id);
            if (friendship == null) return NotFound();
            if (friendshipDto.FriendId != 0) friendship.FriendId = friendshipDto.FriendId;
            _friendshipService.Add(friendship);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int userId, int id)
        {
            var friendship = _friendshipService.GetByUserId(userId).FirstOrDefault(f => f.Id == id);
            if (friendship == null) return NotFound();
            _friendshipService.Delete(id);
            return NoContent();
        }
    }
}
