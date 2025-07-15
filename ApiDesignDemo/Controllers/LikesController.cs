using Microsoft.AspNetCore.Mvc;
using ApiDesignDemo.Services;
using ApiDesignDemo.DTOs;
using ApiDesignDemo.Models;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    [Route("api/posts/{postId}/likes")]
    public class LikesController : BaseController<Like>
    {
        private readonly LikeService _likeService;
        public LikesController(LikeService likeService)
        {
            _likeService = likeService;
        }
        // GET: api/posts/{postId}/likes
        [HttpGet]
        public IActionResult GetByPostId(int postId) => Ok(_likeService.GetByPostId(postId));

        // GET: api/posts/{postId}/likes/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int postId, int id)
        {
            var like = _likeService.GetByPostId(postId).FirstOrDefault(l => l.Id == id);
            if (like == null) return NotFound();
            return Ok(like);
        }

        // POST: api/posts/{postId}/likes
        [HttpPost]
        public IActionResult LikePost(int postId, LikeDto likeDto)
        {
            var like = new Like { PostId = postId, UserId = likeDto.UserId, LikedAt = likeDto.LikedAt };
            _likeService.Add(like);
            return CreatedAtAction(nameof(GetById), new { postId = postId, id = like.Id }, like);
        }

        // PUT: api/posts/{postId}/likes/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int postId, int id, LikeDto likeDto)
        {
            var like = _likeService.GetByPostId(postId).FirstOrDefault(l => l.Id == id);
            if (like == null) return NotFound();
            like.UserId = likeDto.UserId;
            like.LikedAt = likeDto.LikedAt;
            _likeService.Add(like); // Simulate update
            return NoContent();
        }

        // PATCH: api/posts/{postId}/likes/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int postId, int id, LikeDto likeDto)
        {
            var like = _likeService.GetByPostId(postId).FirstOrDefault(l => l.Id == id);
            if (like == null) return NotFound();
            if (likeDto.LikedAt != default) like.LikedAt = likeDto.LikedAt;
            _likeService.Add(like); // Simulate update
            return NoContent();
        }

        // DELETE: api/posts/{postId}/likes/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int postId, int id)
        {
            var like = _likeService.GetByPostId(postId).FirstOrDefault(l => l.Id == id);
            if (like == null) return NotFound();
            _likeService.Delete(id);
            return NoContent();
        }
    }
}
