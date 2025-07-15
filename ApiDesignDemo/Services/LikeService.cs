using ApiDesignDemo.Models;
using ApiDesignDemo.Repositories;
using System.Collections.Generic;

namespace ApiDesignDemo.Services
{
public class LikeService : BaseService<Like>
    {
        private readonly ILikeRepository _likeRepository;
        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public IEnumerable<Like> GetByPostId(int postId) => _likeRepository.GetByPostId(postId);
        public void Add(Like like) => _likeRepository.Add(like);
        public void Delete(int id) => _likeRepository.Delete(id);
    }
}
