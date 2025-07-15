using ApiDesignDemo.Models;
using ApiDesignDemo.Repositories;
using System.Collections.Generic;

namespace ApiDesignDemo.Services
{
public class UserService : BaseService<User>
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll() => _userRepository.GetAll();
        public User? GetById(int id) => _userRepository.GetById(id);
        public void Add(User user) => _userRepository.Add(user);
        public void Update(User user) => _userRepository.Update(user);
        public void Delete(int id) => _userRepository.Delete(id);
    }
}
