using Microsoft.AspNetCore.Mvc;
using ApiDesignDemo.Services;
using ApiDesignDemo.DTOs;
using ApiDesignDemo.Models;

namespace ApiDesignDemo.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : BaseController<Post>
    {
        private readonly PostService _postService;
        public PostsController(PostService postService)
        {
            _postService = postService;
        }
        // GET: api/posts
        [HttpGet]
        public IActionResult GetAll() => Ok(_postService.GetAll());

        // GET: api/posts/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        // GET: api/users/{userId}/posts
        [HttpGet("/api/users/{userId}/posts")]
        public IActionResult GetByUserId(int userId)
        {
            return Ok(_postService.GetByUserId(userId));
        }

        // POST: api/posts
        [HttpPost]
        public IActionResult Create(PostDto postDto)
        {
            var post = new Post { UserId = postDto.UserId, Content = postDto.Content, CreatedAt = postDto.CreatedAt };
            _postService.Add(post);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        // PUT: api/posts/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, PostDto postDto)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();
            post.Content = postDto.Content;
            post.UserId = postDto.UserId;
            post.CreatedAt = postDto.CreatedAt;
            _postService.Update(post);
            return NoContent();
        }

        // PATCH: api/posts/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PostDto postDto)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();
            if (postDto.Content != null) post.Content = postDto.Content;
            _postService.Update(post);
            return NoContent();
        }

        // DELETE: api/posts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _postService.GetById(id);
            if (post == null) return NotFound();
            _postService.Delete(id);
            return NoContent();
        }
    }
}
