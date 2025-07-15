using ApiDesignDemo.Models;
using System.Collections.Generic;

namespace ApiDesignDemo.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        // Additional user-specific methods
    }
}
