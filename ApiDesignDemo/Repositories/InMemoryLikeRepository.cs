using ApiDesignDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiDesignDemo.Repositories
{
    public class InMemoryLikeRepository : ILikeRepository
    {
        private readonly List<Like> _likes = new();
        private int _nextId = 1;
        public IEnumerable<Like> GetByPostId(int postId) => _likes.Where(l => l.PostId == postId);
        public IEnumerable<Like> GetAll() => _likes;
        public Like? GetById(int id) => _likes.FirstOrDefault(l => l.Id == id);
        public void Add(Like like)
        {
            like.Id = _nextId++;
            _likes.Add(like);
        }
        public void Update(Like like)
        {
            var existing = GetById(like.Id);
            if (existing != null)
            {
                existing.UserId = like.UserId;
                existing.PostId = like.PostId;
                existing.LikedAt = like.LikedAt;
            }
        }
        public void Delete(int id)
        {
            var like = GetById(id);
            if (like != null) _likes.Remove(like);
        }
    }
}
