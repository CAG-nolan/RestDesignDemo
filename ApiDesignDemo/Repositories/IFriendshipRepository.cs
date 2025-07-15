using ApiDesignDemo.Models;
using System.Collections.Generic;

namespace ApiDesignDemo.Repositories
{
    public interface IFriendshipRepository : IBaseRepository<Friendship>
    {
        IEnumerable<Friendship> GetByUserId(int userId);
    }
}
