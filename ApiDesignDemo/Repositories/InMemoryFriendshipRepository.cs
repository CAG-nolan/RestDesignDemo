using ApiDesignDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiDesignDemo.Repositories
{
    public class InMemoryFriendshipRepository : IFriendshipRepository
    {
        private readonly List<Friendship> _friendships = new();
        private int _nextId = 1;
        public IEnumerable<Friendship> GetByUserId(int userId) => _friendships.Where(f => f.UserId == userId);
        public IEnumerable<Friendship> GetAll() => _friendships;
        public Friendship? GetById(int id) => _friendships.FirstOrDefault(f => f.Id == id);
        public void Add(Friendship friendship)
        {
            friendship.Id = _nextId++;
            _friendships.Add(friendship);
        }
        public void Update(Friendship friendship)
        {
            var existing = GetById(friendship.Id);
            if (existing != null)
            {
                existing.UserId = friendship.UserId;
                existing.FriendId = friendship.FriendId;
                existing.CreatedAt = friendship.CreatedAt;
            }
        }
        public void Delete(int id)
        {
            var friendship = GetById(id);
            if (friendship != null) _friendships.Remove(friendship);
        }
    }
}
