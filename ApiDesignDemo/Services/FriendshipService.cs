using ApiDesignDemo.Models;
using ApiDesignDemo.Repositories;
using System.Collections.Generic;

namespace ApiDesignDemo.Services
{
public class FriendshipService : BaseService<Friendship>
    {
        private readonly IFriendshipRepository _friendshipRepository;
        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }
        public IEnumerable<Friendship> GetByUserId(int userId) => _friendshipRepository.GetByUserId(userId);
        public void Add(Friendship friendship) => _friendshipRepository.Add(friendship);
        public void Delete(int id) => _friendshipRepository.Delete(id);
    }
}
