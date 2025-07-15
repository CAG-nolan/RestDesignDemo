using ApiDesignDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiDesignDemo.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;
        public IEnumerable<User> GetAll() => _users;
        public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing != null)
            {
                existing.UserName = user.UserName;
                existing.Email = user.Email;
            }
        }
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null) _users.Remove(user);
        }
    }
}
