using ApiDesignDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiDesignDemo.Repositories
{
    public class InMemoryPostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new();
        private int _nextId = 1;
        public IEnumerable<Post> GetAll() => _posts;
        public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);
        public IEnumerable<Post> GetByUserId(int userId) => _posts.Where(p => p.UserId == userId);
        public void Add(Post post)
        {
            post.Id = _nextId++;
            _posts.Add(post);
        }
        public void Update(Post post)
        {
            var existing = GetById(post.Id);
            if (existing != null)
            {
                existing.Content = post.Content;
                existing.UserId = post.UserId;
                existing.CreatedAt = post.CreatedAt;
            }
        }
        public void Delete(int id)
        {
            var post = GetById(id);
            if (post != null) _posts.Remove(post);
        }
    }
}
