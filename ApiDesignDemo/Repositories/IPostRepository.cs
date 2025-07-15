using ApiDesignDemo.Models;
using System.Collections.Generic;

namespace ApiDesignDemo.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetByUserId(int userId);
    }
}
