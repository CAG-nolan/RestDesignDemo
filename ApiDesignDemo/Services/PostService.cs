using ApiDesignDemo.Models;
using ApiDesignDemo.Repositories;
using System.Collections.Generic;

namespace ApiDesignDemo.Services
{
public class PostService : BaseService<Post>
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IEnumerable<Post> GetAll() => _postRepository.GetAll();
        public Post? GetById(int id) => _postRepository.GetById(id);
        public IEnumerable<Post> GetByUserId(int userId) => _postRepository.GetByUserId(userId);
        public void Add(Post post) => _postRepository.Add(post);
        public void Update(Post post) => _postRepository.Update(post);
        public void Delete(int id) => _postRepository.Delete(id);
    }
}
