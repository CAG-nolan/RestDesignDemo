using ApiDesignDemo.Models;
using System.Collections.Generic;

namespace ApiDesignDemo.Repositories
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        IEnumerable<Like> GetByPostId(int postId);
    }
}
