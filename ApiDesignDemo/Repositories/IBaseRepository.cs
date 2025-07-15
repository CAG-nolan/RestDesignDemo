using System.Collections.Generic;

namespace ApiDesignDemo.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
